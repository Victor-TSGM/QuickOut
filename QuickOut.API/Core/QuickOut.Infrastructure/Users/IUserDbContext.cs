using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Users;

namespace QuickOut.Infrastructure.Users
{
    public interface IUserDbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
