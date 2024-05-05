using Microsoft.EntityFrameworkCore;
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
            context.Estabilishments.Remove(entity);
        }

        public async Task<Estabilishment> ValidateAuthenticationCode(string code)
        {
            Estabilishment? dbEntity = await context.Estabilishments
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ValidationCode == code);

            if (dbEntity == null)
            {
                return null;
            }

            return dbEntity;
        }

        public async Task<Estabilishment?> GetById(Guid id)
        {
            Estabilishment? dbEntity = await context.Estabilishments.FindAsync(id);

            if (dbEntity == null)
            {
                return null;
            }

            return dbEntity;
        }

        public void Update(Estabilishment entity)
        {
            context.Estabilishments.Update(entity);
        }

        public void AddSection(Estabilishment entity)
        {
            context.EstabilishmentSections.AddRange(entity.Sections);
        }
    }
}
