using QuickOut.Domain.Common;

namespace QuickOut.Domain.Customers
{
    public class CantAddCustomerIfCPFAlreadyExists : IBusinessRule
    {
        private readonly ICustomerRepository repository;
        public string Cpf { get; private set; }

        public CantAddCustomerIfCPFAlreadyExists(string cpf, ICustomerRepository repository)
        {
            this.Cpf = cpf;
            this.repository = repository;
        }

        public string Message => "CPF_ALREADY_EXISTS";

        public bool IsBroken() => repository.customerCPFAlreadyExists(this.Cpf);
    }
}
