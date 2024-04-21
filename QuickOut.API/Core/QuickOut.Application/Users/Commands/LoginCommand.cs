using QuickOut.Application.Common;
using QuickOut.Domain.Users;
using QuickOut.Library;

namespace QuickOut.Application.Users.Commands
{
    public class LoginCommand : ICommand<LoginResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public LoginCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    public class LoginResult
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public UserRole UserRole { get; set; }
    }

    public class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResult>
    {
        private readonly IUserRepository repository;

        public LoginCommandHandler(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<LoginResult>> Handle(LoginCommand parameters)
        {
            User? user = repository.TryLogin(parameters.Email, parameters.Password);

            if(user == null)
            {
                return Result<LoginResult>.Fail("Usuário ou senha incorretos");
            }

            return Result<LoginResult>.Success(new LoginResult
            {
                Id = user.Id,
                UserName = user.UserName,
                UserRole = user.UserRole
            });
        }
    }
}
