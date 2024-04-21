using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Orders;

namespace QuickOut.Infrastructure.Orders
{
    public interface IOrderDbContext
    {
        DbSet<Order> Orders { get; set; }
    }
}
