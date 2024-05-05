using QuickOut.Library;

namespace QuickOut.DomainEvents;

public class AuthenticateEstabilishmentEvent : IDomainEvent
{
    public string Code { get; set; }
    public Guid CustomerId { get; set; }

    public AuthenticateEstabilishmentEvent(string code, Guid customerId)
    {
        this.Code = code;
        this.CustomerId = customerId;
    }
}