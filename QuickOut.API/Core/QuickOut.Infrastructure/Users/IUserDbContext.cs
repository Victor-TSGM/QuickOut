using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Common;
using QuickOut.Domain.Users;

namespace QuickOut.Infrastructure.Users
{
    public interface IUserDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
