using QuickOut.Application.Common;
using QuickOut.DomainEvents;
using QuickOut.Library;

namespace QuickOut.Application.Customers.EventHandlers;

public class AuthenticateCustomerEventHandler : ITransactionalDomainEventHandler<AuthenticateCustomerEvent>
{
    private readonly StartSectionCommandHandler commandHandler;

    public AuthenticateCustomerEventHandler(StartSectionCommandHandler commandHandler)
    {
        this.commandHandler = commandHandler;
    }

    public async Task<Result> Handle(AuthenticateCustomerEvent parameters)
    {
        return await this.commandHandler.Handle(new StartSectionCommand(parameters.EstabilishmentId, parameters.CustomerId));
    }
}