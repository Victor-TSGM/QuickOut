using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Estabilishments;

namespace QuickOut.Infrastructure.Estabilishments
{
    public interface IEstabilishmentDbContext 
    {
        public DbSet<Estabilishment> Estabilishments { get; set; }
        public DbSet<EstabilishmentSection> EstabilishmentSections { get; set; }
        
    }
}
