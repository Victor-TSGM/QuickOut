using Microsoft.EntityFrameworkCore;
using QuickOut.Domain.Customers;
using QuickOut.Infrastructure.Customers;

namespace QuickOut.Tests
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerDbContext context;

        public FakeCustomerRepository(ICustomerDbContext context)
        {
            this.context = context;
        }

        public void Add(Customer entity)
        {
            context.Customers.Add(entity);
        }

        public bool customerCPFAlreadyExists(string cpf)
        {
            return context.Customers.Any(x => x.CPF == cpf);
        }

        public bool customerEmailAlreadyExists(string email)
        {
            return context.Customers.Any(x => x.Email == email);
        }

        public void Delete(Customer entity)
        {
            Customer dbEntity = context.Customers.FirstOrDefault(x => x.Id == entity.Id);

            if(dbEntity == null)
            {
                return;
            }

            context.Customers.Remove(dbEntity);
        }

        public Task<Customer?> GetById(Guid id)
        {
            return context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(Customer entity)
        {
            context.Customers.Update(entity);           
        }
    }
}