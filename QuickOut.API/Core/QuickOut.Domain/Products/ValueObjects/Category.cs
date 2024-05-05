using QuickOut.Library;

namespace QuickOut.Domain.Products.ValueObjects
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Description { get; private set; }
        
        protected Category() {}

        public Result<Category> New(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return Result<Category>.Fail("Descrição inválida");
            }

            Category category = new Category()
            {
                Id = Guid.NewGuid(),
                Description = description
            };

            return Result<Category>.Success(category);
        }
    }
}