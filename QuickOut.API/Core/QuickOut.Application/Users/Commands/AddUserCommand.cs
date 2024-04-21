using QuickOut.Application.Common;
using QuickOut.Domain.Users;
using QuickOut.Library;

namespace QuickOut.Application.Users.Commands
{
    public class AddUserCommand : ICommand<Guid>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public AddUserCommand(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }
    }

    public class AddUserCommandHandler : ICommandHandler<AddUserCommand, Guid>
    {
        private readonly IUserRepository repository;
        private readonly IDomainEventManager domainEventManager;

        public AddUserCommandHandler(IUserRepository repository, IDomainEventManager domainEventManager)
        {
            this.repository = repository;
            this.domainEventManager = domainEventManager;
        }

        public async Task<Result<Guid>> Handle(AddUserCommand parameters)
        {
            Result<User> createResult = User.New(parameters.UserName, parameters.Email, parameters.Password, UserRole.Customer);

            if(!createResult.Succeeded)
            {
                return Result<Guid>.Fail("Não foi possível adicionar o usuário");
            }

            repository.Add(createResult.Data);

            return Result<Guid>.Success(createResult.Data.Id);
        }
    }
}
