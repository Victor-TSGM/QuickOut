using QuickOut.Library;

namespace QuickOut.Domain.Estabilishments
{
    public interface IEstabilishmentRepository : IRepository<Estabilishment>
    {
        Task<Estabilishment> ValidateAuthenticationCode(string code);
        void AddSection(Estabilishment entity);
    }
}
