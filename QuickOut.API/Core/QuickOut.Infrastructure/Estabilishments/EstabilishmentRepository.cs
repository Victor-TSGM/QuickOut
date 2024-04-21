using QuickOut.Domain.Estabilishments;

namespace QuickOut.Infrastructure.Estabilishments
{
    public class EstabilishmentRepository : IEstabilishmentRepository
    {
        private readonly IEstabilishmentDbContext context;

        public EstabilishmentRepository(IEstabilishmentDbContext context)
        {
            this.context = context;
        }
        public void Add(Estabilishment entity)
        {
            context.Estabilishments.Add(entity);
        }

        public void Delete(Estabilishment entity)
        {
            throw new NotImplementedException();
        }

        public Task<Estabilishment?> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Estabilishment entity)
        {
            throw new NotImplementedException();
        }
    }
}
