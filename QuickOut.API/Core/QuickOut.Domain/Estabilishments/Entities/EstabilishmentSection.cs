using QuickOut.Library;

namespace QuickOut.Domain.Estabilishments
{

    public enum SectionStatus
    {
        Active,
        Closed
    }
    public class EstabilishmentSection
    {
        public Guid Id { get; private set; }
        public Guid EstabilishmentId { get; private set; }
        public Guid CustomerId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        //public string Token { get; private set; }
        public SectionStatus Status { get; private set; }

        protected EstabilishmentSection()
        {

        }

        public static Result<EstabilishmentSection> StartSection(
            Guid customerId,
            Estabilishment estabilishment
        )
        {
            EstabilishmentSection entity = new EstabilishmentSection()
            {
                Id = Guid.NewGuid(),
                CustomerId = customerId,
                EstabilishmentId = estabilishment.Id,
                StartDate = DateTime.Now,
                Status = SectionStatus.Active
            };

            return Result<EstabilishmentSection>.Success(entity);
        }

        public void CloseSection()
        {
            this.EndDate = DateTime.UtcNow;
        }
    }
}