using QuickOut.Library;

namespace QuickOut.DomainEvents;

public class AuthenticateCustomerEvent : IDomainEvent
{
    public Guid EstabilishmentId { get; set; }
    public Guid CustomerId { get; set; }

    public AuthenticateCustomerEvent(Guid estabilishment, Guid customerId)
    {
        this.EstabilishmentId = estabilishment;
        this.CustomerId = customerId;
    }
}