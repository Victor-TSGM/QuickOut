using QuickOut.Domain.Common;

namespace QuickOut.Domain.Customers
{
    public class CantAddCustomerIfEmailAlreadyExists : IBusinessRule
    {
        private readonly ICustomerRepository repository;
        public string email { get; private set; }

        public CantAddCustomerIfEmailAlreadyExists(string email, ICustomerRepository repository)
        {
            this.email = email;
            this.repository = repository;
        }

        public string Message => "EMAIL_ALREADY_EXISTS";

        public bool IsBroken() => repository.customerEmailAlreadyExists(this.email);
    }
}
