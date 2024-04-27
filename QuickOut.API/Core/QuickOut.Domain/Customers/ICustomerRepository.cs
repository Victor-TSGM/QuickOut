using QuickOut.Library;

namespace QuickOut.Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        bool customerEmailAlreadyExists(string email);
        bool customerCPFAlreadyExists(string cpf);
    }
}
