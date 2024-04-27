using QuickOut.Library;

namespace QuickOut.DomainEvents
{
    public class CustomerCreatedEvent : IDomainEvent
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public CustomerCreatedEvent(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}