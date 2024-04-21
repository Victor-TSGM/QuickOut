using QuickOut.Library;

namespace QuickOut.Domain.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public UserRole UserRole { get; private set; }

        protected User() { }

        public static Result<User> New(
            string userName,
            string email,
            string password,
            UserRole userRole)
        {
            User entity = new User()
            {
                Id = Guid.NewGuid(),
                UserName = userName,
                Email = email,
                Password = password,
                UserRole = userRole
            };

            return Result<User>.Success(entity);
        }

    }
}
