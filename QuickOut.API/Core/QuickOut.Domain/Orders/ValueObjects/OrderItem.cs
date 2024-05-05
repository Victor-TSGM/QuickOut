using QuickOut.Domain.Common.Shared;
using QuickOut.Library;

namespace QuickOut.Domain.Orders
{
    public class OrderItem : ValueObject
    {
        public Guid ProductId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public double Value { get; private set; }
        public double Weight { get; private set; }
        
        public OrderItem(Guid productId, string name, string description, double value, double weight)
        {
            ProductId = productId;
            Name = name;
            Description = description;
            Value = value;
            Weight = weight;
        }
    }
}