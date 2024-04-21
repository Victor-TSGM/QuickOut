namespace QuickOut.Domain.Orders
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Value { get; set; }
        public double Weight { get; set; }

        public OrderItem(Guid id, Guid orderId, Guid productId, string name, string description, double value, double weight)
        {
            Id = id;
            OrderId = orderId;
            ProductId = productId;
            Name = name;
            Description = description;
            Value = value;
            Weight = weight;
        }
    }
}
