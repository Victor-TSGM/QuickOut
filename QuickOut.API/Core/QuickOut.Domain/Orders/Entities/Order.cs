using QuickOut.Library;

namespace QuickOut.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid EstabilishmentId { get; private set; }
        public DateTime Date { get; private set; }
        
        public int OrderItemsQuantity => OrderItems.Count;
        public double TotalValue  => OrderItems.Sum(x => x.Value);
        public OrderStatus OrderStatus { get; private set; }
        public List<OrderItem> OrderItems { get; private set; } = new();

        protected Order() { }

        public static Result<Order> New(Guid customerId, Guid estabilishmentId)
        {
            Order order = new Order()
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                EstabilishmentId = estabilishmentId,
                Date = DateTime.Now,
                OrderStatus = OrderStatus.InProgress,
                OrderItems = new List<OrderItem>()
            };

            return Result<Order>.Success(order);    
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            this.OrderItems.Add(orderItem);
        }

        public void RemoveOrderItem(OrderItem orderItem)
        {
            this.OrderItems.Remove(orderItem);
        }
        
        // public Result MakePayment() {}
        
        // public Result GenerateInvoice() {}
        
    }
    public enum OrderStatus
    {
        InProgress,
        Canceled,
        Finished
    }
}