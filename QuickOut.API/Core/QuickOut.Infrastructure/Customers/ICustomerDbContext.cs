using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Common;
using QuickOut.Domain.Customers;

namespace QuickOut.Infrastructure.Customers
{
    public interface ICustomerDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
