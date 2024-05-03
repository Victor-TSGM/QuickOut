using QuickOut.Domain.Common;
using QuickOut.Library;

namespace QuickOut.Domain.Estabilishments
{
    public class Estabilishment
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CNPJ { get; private set; }
        public Address Address { get; private set; }
        //public Location Location { get; private set; }
        public TimeSpan OperationStart { get; private set; }
        public TimeSpan OperationsEnd { get; private set; }
        public string? LogoType { get; private set; }
        public EstabilishmentStatus? Status { get; private set; }
        public string Email { get; private set; }
        public List<Guid>? Products { get; private set; }

        protected Estabilishment() { }

        public static Result<Estabilishment> New(
            string name,
            string cnpj,
            Address address,
            TimeSpan operationStart,
            TimeSpan operationEnd,
            string email
            )
        {
            Estabilishment entity = new Estabilishment()
            {
                Name = name,
                CNPJ = cnpj,
                Address = address,
                OperationStart = operationStart,
                OperationsEnd = operationEnd,
                Email = email,
            };

            return Result<Estabilishment>.Success( entity );
        }

        public static Result Update(Estabilishment entity)
        {
            return Result.Success();
        }
    }

    public enum EstabilishmentStatus
    {
        Opened,
        Closed
    }
}