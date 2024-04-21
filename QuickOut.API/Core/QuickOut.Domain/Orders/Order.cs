namespace QuickOut.Domain.Orders
{
    public class Order
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid EstabilishmentId { get; private set; }
        public DateTime Date { get; private set; }
        public double TotalValue { get; private set; }
        public OrderStatus OrderStatus { get; private set; }
        public List<Guid>? OrderItems { get; private set; }
    }
    public enum OrderStatus
    {
        Pending,
        Canceled,
        finished
    }
}