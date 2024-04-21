using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Products;

namespace QuickOut.Infrastructure.Products
{
    public interface IProductDbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
