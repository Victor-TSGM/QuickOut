using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Users;

namespace QuickOut.Infrastructure.Users
{
    public class UserRepository : IUserRepository
    {

        private readonly IUserDbContext context;

        public UserRepository(IUserDbContext context)
        {
            this.context = context;
        }

        public void Add(User entity)
        {
            context.Users.Add(entity);
        }

        public bool AlreadyHasMail(string email)
        {
            return context.Users.Any(x => x.Email == email);
        }

        public void Delete(User entity)
        {
            context.Users.Remove(entity);
        }

        public async Task<User?> GetById(Guid id)
        {
            User? dbEntity = await context.Users.FindAsync(id);

            if (dbEntity == null)
            {
                return null;
            }

            return dbEntity;
        }

        public User? TryLogin(string email, string password)
        {
            return context.Users
                .AsNoTracking()
                .FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        public void Update(User entity)
        {
            context.Users.Update(entity);
        }
    }
}
