using Microsoft.Extensions.DependencyInjection;
using QuickOut.Application.Common;
using QuickOut.Intrastructure.Common;
using QuickOut.Library;
using System.Collections.Concurrent;

namespace QuickOut.Infrastructure.Common
{
    public class VicthotMediator
    {
        private readonly IServiceProvider provider;
        private readonly VicthorMediatorConfiguration configuration;
        private IServiceScope scope;
        private IDomainEventManager domainEventManager;

        public VicthotMediator(IServiceProvider provider, VicthorMediatorConfiguration configuration)
        {
            this.provider = provider;
            this.configuration = configuration;
            scope = this.provider.CreateScope();
            domainEventManager = scope.ServiceProvider.GetRequiredService<IDomainEventManager>();
        }

        public async Task<Result<TResult>> Execute<TResult>(ICommand<TResult> parameters, List<int>? privilegesOrRoles = null)
        {
            try
            {
                Type? commandHandlerType = configuration.RequestHandlers[parameters.GetType()];

                if (commandHandlerType == null)
                {
                    return Result<TResult>.Fail("Nenhum comando atribuído para essa requisição");
                }

                AuthorizePrivilegeAttribute? securityAccess = parameters.GetType()
                    .GetCustomAttributes(true)
                    .OfType<AuthorizePrivilegeAttribute>()
                    .FirstOrDefault();

                if (securityAccess != null)
                {
                    bool accessResult = securityAccess.IsAuthorized(privilegesOrRoles);

                    if (!accessResult)
                    {
                        return Result<TResult>.Fail("Usuário não possui permissão para executar essa ação");
                    }
                }

                QuickOutContext? context = scope.ServiceProvider.GetRequiredService<QuickOutContext>();

                UnitOfWork? unitOfWork = new UnitOfWork(context);

                Result<TResult> response = await ExecuteCommand<TResult>(commandHandlerType, parameters, scope);

                if (!response.Succeeded)
                {
                    unitOfWork.Rollback();
                    return response;
                }

                Result domainEventsResponse = await DispatchDomainEvents();

                if (!domainEventsResponse.Succeeded)
                {
                    unitOfWork.Rollback();
                    return Result<TResult>.Fail(domainEventsResponse.Messages);
                }

                // Envia os domain events e salva a transação
                Result? commitResponse = unitOfWork.Commit();

                if (!commitResponse.Succeeded)
                {
                    return Result<TResult>.Fail(commitResponse.Messages);
                }

                return response;
            }
            catch (Exception ex)
            {
                return Result<TResult>.Fail(ex.Message);
            }
        }

        public async Task<Result> DispatchDomainEvents()
        {
            try
            {
                IVicthorEventBus? eventBus = scope.ServiceProvider.GetRequiredService<IVicthorEventBus>();

                ConcurrentBag<string>? resultMessages = new ConcurrentBag<string>();

                // Enquanto houver domain events para processar
                while (domainEventManager.HasPendingEvents())
                {
                    List<Task> tasks = new List<Task>();

                    foreach (IDomainEventInfo eventInfo in domainEventManager.GetPendingDomainEvents())
                    {
                        tasks.Add(
                            Task.Run(async () =>
                            {
                                List<Task> handlerTasks = new List<Task>();

                                // salva na tabela outbox, para eventos de consistencia eventual
                                if (eventInfo.AllowEventualConsistency)
                                {
                                    await eventBus.PublishEventualConsistencyDomainEvent(eventInfo.DomainEvent);
                                }

                                if (!configuration.TransactionalEventHandlers.ContainsKey(eventInfo.DomainEvent.GetType()))
                                {
                                    return;
                                }

                                // processa os transacionais
                                List<Type>? eventHandlers = configuration.TransactionalEventHandlers[eventInfo.DomainEvent.GetType()];

                                foreach (Type? eventHandler in eventHandlers)
                                {
                                    handlerTasks.Add(
                                        Task.Run(async () =>
                                        {
                                            Result? response = await ExecuteEvent(eventHandler, eventInfo.DomainEvent, scope);

                                            if (!response.Succeeded)
                                            {
                                                foreach (string? message in response.Messages)
                                                {
                                                    resultMessages.Add(message);
                                                }
                                            }
                                        })
                                    );
                                }

                                await Task.WhenAll(handlerTasks.ToArray());
                            })
                        );

                        // Remove o evento processado
                        domainEventManager.Remove(eventInfo);
                    }

                    await Task.WhenAll(tasks.ToArray());
                }

                if (resultMessages.Any())
                {
                    return Result.Fail(resultMessages.ToList());
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }

        private async Task<Result<TResult>> ExecuteCommand<TResult>(Type commandHandlerType, dynamic parameters, IServiceScope scope)
        {
            dynamic command = scope.ServiceProvider.GetRequiredService(commandHandlerType) as dynamic;

            return await command.Handle(parameters);
        }

        private async Task<Result> ExecuteEvent(Type commandHandlerType, dynamic parameters, IServiceScope scope)
        {
            dynamic command = scope.ServiceProvider.GetRequiredService(commandHandlerType) as dynamic;

            return await command.Handle(parameters);
        }

        public void Dispose()
        {
            scope.Dispose();
        }
    }
}
