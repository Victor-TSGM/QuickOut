using QuickOut.Domain.Products.ValueObjects;
using QuickOut.Library;

namespace QuickOut.Domain.Products
{
    public class Product
    {
        public Guid Id { get; private set; }
        public long BarCode { get; private set; }
        public string Name { get; private set; }
        public Category Category { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }
        
        public ProductStatus Status { get; private set; }
        public int AvaliableQuantity { get; private set; }

        public Product() { }

        public static Result<Product> New(long barCode, string name, string description, double price, int quantity, Category category)
        {
            Product entity = new Product()
            {
                Id = Guid.NewGuid(),
                BarCode = barCode,
                Name = name,
                Description = description,
                Price = price,
                AvaliableQuantity = quantity,
                Category = category
            };

            return Result<Product>.Success(entity);
        }
    }

    public enum ProductStatus
    {
        Inactive,
        Active
    }
}