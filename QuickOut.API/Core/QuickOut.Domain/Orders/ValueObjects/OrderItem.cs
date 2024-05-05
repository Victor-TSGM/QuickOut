using QuickOut.Library;

namespace QuickOut.Domain.Orders
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; private set; }
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Value { get; private set; }
        public double Weight { get; private set; }
        
        public OrderItem(Guid orderId, Guid productId, string name, string description, double value, double weight)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
            Name = name;
            Description = description;
            Value = value;
            Weight = weight;
        }
    }
}