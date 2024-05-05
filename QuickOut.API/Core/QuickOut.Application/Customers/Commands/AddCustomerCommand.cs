using System.Diagnostics;
using QuickOut.Application.Common;
using QuickOut.Domain.Common;
using QuickOut.Domain.Customers;
using QuickOut.Domain.Customers.ValueObjects;
using QuickOut.DomainEvents;
using QuickOut.Library;

namespace QuickOut.Application.Customers
{
    public class AddCustomerCommand : ICommand<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int AddressNumber { get; set; }
        public string ZipCode { get; set; }

        public AddCustomerCommand(
            string firstName,
            string lastName,
            string cpf, 
            string phone, 
            string email, 
            string password, 
            DateTime birthDate, 
            string country, 
            string state, 
            string city,
            string street, 
            int addressNumber, 
            string zipCode)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Phone = phone;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Country = country;
            State = state;
            City = city;
            Street = street;
            AddressNumber = addressNumber;
            ZipCode = zipCode;
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

            Name name;
            Cpf cpf;
            Email email;
            PhoneNumber phone;
            Address address;

            Result validations = TryParseInput(request, out name, out cpf, out email, out phone, out address);

            if (!validations.Succeeded)
            {
                return Result<Guid>.Fail(validations.Messages).AsTask();
            }

            Result<Customer> createResult = Customer.New(
                name,
                cpf,
                phone,
                email,
                request.BirthDate,
                address,
                repository
                );

            if(!createResult.Succeeded)
            {
                return Result<Guid>.Fail(createResult.Messages).AsTask();
            }

            repository.Add(createResult.Data);

            domainEvent.Add(new CustomerCreatedEvent(request.Email, request.Password));

            return Result<Guid>.Success(createResult.Data.Id).AsTask();
        }

        private Result TryParseInput(
            AddCustomerCommand request,
            out Name name,
            out Cpf cpf,
            out Email email,
            out PhoneNumber phone,
            out Address address
        )
        {
            Result<Name> nameResult = Name.New(request.FirstName, request.LastName);
            Result<Cpf> cpfResult = Cpf.New(request.Cpf);
            Result<Email> emailResult = Email.New(request.Email);
            Result<PhoneNumber> phoneResult = PhoneNumber.New(request.Phone);
            Result<Address> addressResult = Address.New(
                request.Country,
                request.State,
                request.City,
                request.Street,
                request.AddressNumber,
                request.ZipCode);

            name = nameResult.Data;
            cpf = cpfResult.Data;
            email = emailResult.Data;
            phone = phoneResult.Data;
            address = addressResult.Data;

            if (ResultHelpers.IsAnyFailed(nameResult, cpfResult, emailResult, phoneResult, addressResult))
            {
                return ResultHelpers.FailWithMessages(nameResult, cpfResult, emailResult, phoneResult, addressResult);
            }

            return Result.Success();
        }
    }
}