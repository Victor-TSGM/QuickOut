using QuickOut.Application.Common;
using QuickOut.DomainEvents;
using QuickOut.Library;

namespace QuickOut.Application.Estabilishments.EventHandlers;

public class AuthenticateEstabelishmentEventHandler : ITransactionalDomainEventHandler<AuthenticateEstabilishmentEvent>
{
    private readonly AuthenticateCustomerCommandHandler commandHandler;

    public AuthenticateEstabelishmentEventHandler(AuthenticateCustomerCommandHandler commandHandler)
    {
        this.commandHandler = commandHandler;
    }

    public async Task<Result> Handle(AuthenticateEstabilishmentEvent parameters)
    {
        return await this.commandHandler.Handle(new AuthenticateCustomerCommand(parameters.Code, parameters.CustomerId));
    }
}