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

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
