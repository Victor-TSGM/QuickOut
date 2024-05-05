using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Customers;

namespace QuickOut.Infrastructure.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ICustomerDbContext context;
        public CustomerRepository(ICustomerDbContext context)
        {
            this.context = context;
        }
        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
        }

        public void Delete(Customer entity)
        {
            context.Customers.Remove(entity);
        }

        public async Task<Customer?> GetById(Guid id)
        {
            Customer? dbEntity = await context.Customers.FindAsync(id);

            if (dbEntity == null)
            {
                return null;
            }

            return dbEntity;
        }

        public async void Update(Customer entity)
        {

            context.Customers.Update(entity); ;
        }
        public bool customerEmailAlreadyExists(string email)
        {
            return context.Customers.Any(x => x.Email.Address == email);
        }

        public bool customerCPFAlreadyExists(string cpf)
        {
            return context.Customers.Any(x => x.CPF.Document == cpf);
        }

        public void AddSection(Customer entity)
        {
            context.CustomerSections.AddRange(entity.Sections);
        }
    }
}