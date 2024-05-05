using QuickOut.Library;

namespace QuickOut.Domain.Customers
{

    public enum SectionStatus
    {
        Active,
        Closed
    }
    public class CustomerSection
    {
        public Guid Id { get; private set; }
        
        public Customer Customer { get; private set; }
        public Guid EstabilishmentId { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public string Token { get; private set; }
        
        public SectionStatus Status { get; private set; }
        
        

        protected CustomerSection()
        {

        }

        public static Result<CustomerSection> StartSection(
                Guid estabilishmentId,
                Customer customer,
                DateTime startDate,
                string token
            )
        {
            CustomerSection entity = new CustomerSection()
            {
                Id = Guid.NewGuid(),
                Customer = customer,
                EstabilishmentId = estabilishmentId,
                StartDate = startDate,
                Token = token,
                Status = SectionStatus.Active
            };

            return Result<CustomerSection>.Success(entity);
        }

        public void CloseSection()
        {
            this.EndDate = DateTime.UtcNow;
        }
    }
}