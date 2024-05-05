using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Common;
using QuickOut.Domain.Customers;

namespace QuickOut.Infrastructure.Customers
{
    public interface ICustomerDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerSection> CustomerSections { get; set; }
    }
}
