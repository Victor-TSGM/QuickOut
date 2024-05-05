using QuickOut.Domain.Common;
using QuickOut.Domain.Customers.ValueObjects;
using QuickOut.Library;

namespace QuickOut.Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public Name Name { get; private set; }
        public Cpf CPF { get; private set; }
        public PhoneNumber Phone { get; private set; }
        public Email Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
        public CustomerStatus CustomerStatus { get; private set; }
        public List<CustomerSection> Sections { get; private set; } = new();

        public Customer()
        {

        }

        public static Result<Customer> New(
                Name name,
                Cpf cpf,
                PhoneNumber phone,
                Email email,
                DateTime birthDate,
                Address address,
                ICustomerRepository repository
            )
        {
            Customer entity = new Customer()
            {
                Id = Guid.NewGuid(),
                Name = name,
                CPF = cpf,
                Phone = phone,
                Email = email,
                BirthDate = birthDate,
                Address = address,
                CustomerStatus = CustomerStatus.Active,
            };

            Result rulesResult = CheckRules(
                new CantAddCustomerIfCPFAlreadyExists(cpf.Document, repository),
                new CantAddCustomerIfEmailAlreadyExists(email.Address, repository)
                );

            if (!rulesResult.Succeeded)
            {
                return Result<Customer>.Fail(rulesResult.Messages);
            }

            return Result<Customer>.Success(entity);
        }

        private static Result CheckRules(params IBusinessRule[] rules)
        {
            foreach (var rule in rules)
            {
                if (rule.IsBroken())
                {
                    return Result.Fail(rule.Message);
                }
            }

            return Result.Success();
        }

        public void AddSection(CustomerSection section)
        {
            foreach (var item in this.Sections)
            {
                if (item.Status == SectionStatus.Active)
                {
                    item.CloseSection();
                }
            }
            
            this.Sections.Add(section);
        }
    }

    public enum CustomerStatus
    {
        Active,
        Inactive,
    }
}