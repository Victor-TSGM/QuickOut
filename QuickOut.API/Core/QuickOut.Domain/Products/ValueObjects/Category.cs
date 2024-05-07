using QuickOut.Domain.Common.Shared;
using QuickOut.Library;

namespace QuickOut.Domain.Products.ValueObjects
{
    public class Category : ValueObject
    {
        public string Description { get; private set; }
        
        protected Category() {}

        public static Result<Category> New(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                return Result<Category>.Fail("Descrição inválida");
            }

            Category category = new Category()
            {
                Description = description
            };

            return Result<Category>.Success(category);
        }
    }
}