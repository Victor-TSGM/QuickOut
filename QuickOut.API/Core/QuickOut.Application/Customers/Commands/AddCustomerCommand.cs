using QuickOut.Application.Common;
using QuickOut.Domain.Common;
using QuickOut.Domain.Customers;
using QuickOut.Library;

namespace QuickOut.Application.Customers
{
    public class AddCustomerCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int AddressNumber { get; set; }
        public string PostalCode { get; set; }

        public AddCustomerCommand(
            string name,
            string cpf, 
            string phone, 
            string email, 
            string password, 
            DateTime birthDate, 
            string country, 
            string state, 
            string street, 
            int addressNumber, 
            string postalCode)
        {
            Name = name;
            CPF = cpf;
            Phone = phone;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Country = country;
            State = state;
            Street = street;
            AddressNumber = addressNumber;
            PostalCode = postalCode;
        }
    }

    public class AddCustomerCommandHandler : ICommandHandler<AddCustomerCommand, Guid>
    {
        private readonly ICustomerRepository repository;
        private readonly IDomainEventManager domainEvent;

        public AddCustomerCommandHandler(ICustomerRepository repository, IDomainEventManager domainEvent)
        {
            this.repository = repository;
            this.domainEvent = domainEvent;
        }

        public Task<Result<Guid>> Handle(AddCustomerCommand request)
        {

            Address userAddress = new Address()
            {
                Country = request.Country,
                State = request.State,
                Street = request.Street,
                AddressNumber = request.AddressNumber,
                PostalCode = request.PostalCode,
            };

            Result<Customer> createResult = Customer.New(
                request.Name,
                request.CPF,
                request.Phone,
                request.Email,
                request.BirthDate,
                userAddress
                );

            if(!createResult.Succeeded)
            {
                return Result<Guid>.Fail(createResult.Messages).AsTask();
            }

            repository.Add(createResult.Data);

            return Result<Guid>.Success(createResult.Data.Id).AsTask();
        }
    }
}
