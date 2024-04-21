using QuickOut.Domain.Orders;

namespace QuickOut.Infrastructure.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderDbContext context;

        public OrderRepository(IOrderDbContext context)
        {
            this.context = context;
        }
        public void Add(Order entity)
        {
            context.Orders.Add(entity);
        }

        public void Delete(Order entity)
        {
            context.Orders.Remove(entity);
        }

        public async Task<Order?> GetById(Guid id)
        {
            Order? dbEntity = await context.Orders.FindAsync(id);

            if(dbEntity == null)
            {
                return null;
            }

            return dbEntity;    
        }

        public void Update(Order entity)
        {
            context.Orders.Update(entity);
        }
    }
}
