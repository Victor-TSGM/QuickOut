using QuickOut.Library;

namespace QuickOut.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid EstabilishmentId { get; private set; }
        public DateTime Date { get; private set; }
        public double TotalValue { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public List<Guid>? OrderItems { get; private set; }

        protected Order() { }

        public static Result<Order> New(Guid customerId, Guid estabilishmentId)
        {
            Order order = new Order()
            {
                CustomerId = customerId,
                EstabilishmentId = estabilishmentId,
                Date = DateTime.Now,
                OrderStatus = OrderStatus.Pending,
                TotalValue = 0,
                OrderItems = new List<Guid>()
            };

            return Result<Order>.Success(order);    
        }
    }
    public enum OrderStatus
    {
        Pending,
        Canceled,
        finished
    }
}