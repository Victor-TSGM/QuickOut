using QuickOut.Library;

namespace QuickOut.Domain.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User? TryLogin(string email, string password);

        bool AlreadyHasMail(string email);
    }
}
