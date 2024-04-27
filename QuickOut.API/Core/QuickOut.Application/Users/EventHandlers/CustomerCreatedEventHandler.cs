using QuickOut.Application.Common;
using QuickOut.Application.Users.Commands;
using QuickOut.DomainEvents;
using QuickOut.Library;

namespace QuickOut.Application.Users
{
    public class CustomerCreatedEventHandler : ITransactionalDomainEventHandler<CustomerCreatedEvent>
    {
        private readonly AddUserCommandHandler commandHandler;

        public CustomerCreatedEventHandler(AddUserCommandHandler commandHandler)
        {
            this.commandHandler = commandHandler;
        }

        public async Task<Result> Handle(CustomerCreatedEvent parameters)
        {
            string userName = parameters.Email.Split('@')[0];

            return await this.commandHandler.Handle(new AddUserCommand(userName, parameters.Email, parameters.Password));
        }
    }
}