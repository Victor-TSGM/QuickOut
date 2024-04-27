using QuickOut.Domain.Common;
using QuickOut.Library;

namespace QuickOut.Domain.Customers
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Address Address { get; private set; }
        public CustomerStatus CustomerStatus { get; private set; }
        public List<Section>? Sections { get; private set; }


        protected Customer()
        {

        }

        public static Result<Customer> New(
                string name,
                string cpf,
                string phone,
                string email,
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
                new CantAddCustomerIfCPFAlreadyExists(cpf, repository),
                new CantAddCustomerIfEmailAlreadyExists(email, repository)
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
    }

    public enum CustomerStatus
    {
        Active,
        Inactive,
    }
}
