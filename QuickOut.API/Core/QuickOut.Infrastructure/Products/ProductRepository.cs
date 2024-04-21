using QuickOut.Domain.Products;

namespace QuickOut.Infrastructure.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDbContext context;

        public ProductRepository(IProductDbContext context)
        {
            this.context = context;
        }
        public void Add(Product entity)
        {
            context.Products.Add(entity);
        }

        public void Delete(Product entity)
        {
            context.Products.Remove(entity);
        }

        public async Task<Product?> GetById(Guid id)
        {
            Product? dbEntity = await context.Products.FindAsync(id);

            if( dbEntity == null)
            {
                return null;
            }

            return dbEntity;
        }

        public void Update(Product entity)
        {
            context.Products.Update(entity);
        }
    }
}
