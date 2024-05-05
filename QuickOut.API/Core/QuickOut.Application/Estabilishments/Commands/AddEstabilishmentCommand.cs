using QuickOut.Application.Common;
using QuickOut.Domain.Common;
using QuickOut.Domain.Estabilishments;
using QuickOut.Domain.Estabilishments.ValueObjects;
using QuickOut.Library;

namespace QuickOut.Application.Estabilishments
{
    public class AddEstabilishmentCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string Email { get; set; }
        public double OperationStart { get; set; }
        public double OperationEnd { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int AddressNumber { get; set; }
        public string ZipCode { get; set; }

        public AddEstabilishmentCommand(string name, string cnpj, string email, double operationStart, double operationEnd, string country, string state, string city, string street, int addressNumber, string zipCode)
        {
            Name = name;
            CNPJ = cnpj;
            Email = email;
            OperationStart = operationStart;
            OperationEnd = operationEnd;
            Country = country;
            State = state;
            City = city;
            Street = street;
            AddressNumber = addressNumber;
            ZipCode = zipCode;
        }
    }
    public class AddEstabilishmentCommandHandler : ICommandHandler<AddEstabilishmentCommand, Guid>
    {
        private readonly IEstabilishmentRepository repository;
        private readonly IDomainEventManager domainEvent;

        public AddEstabilishmentCommandHandler(IEstabilishmentRepository repository, IDomainEventManager domainEvent)
        {
            this.repository = repository;
            this.domainEvent = domainEvent;
        }

        public async Task<Result<Guid>> Handle(AddEstabilishmentCommand request)
        {
            string name;
            Cnpj cnpj;
            Email email;
            Address address;
            TimeSpan operationStart;
            TimeSpan operationEnd;

            Result result = TryParseInput(request, out name, out cnpj, out email, out address, out operationStart, out operationEnd);

            if(!result.Succeeded)
            {
                return Result<Guid>.Fail(result.Messages);
            }
           

            Result<Estabilishment> createResult = Estabilishment.New(
                name, cnpj, address, operationStart, operationEnd, email);

            if(!createResult.Succeeded)
            {
                return Result<Guid>.Fail(createResult.Messages);
            }

            repository.Add(createResult.Data);

            return Result<Guid>.Success(createResult.Data.Id);
        }

        private Result TryParseInput(
            AddEstabilishmentCommand request, 
            out string name, 
            out Cnpj cnpj, 
            out Email email,
            out Address address,
            out TimeSpan operationStart, 
            out TimeSpan operationEnd)
        {
            Result<string> nameResult = Result<string>.Success(request.Name);
            Result<Cnpj> cnpjResult = Cnpj.New(request.CNPJ);
            Result<Email> emailResult = Email.New(request.Email);
            Result<TimeSpan> operationStartResult = Result<TimeSpan>.Success(TimeSpan.FromMilliseconds(request.OperationStart));
            Result<TimeSpan> operationEndResult = Result<TimeSpan>.Success(TimeSpan.FromMilliseconds(request.OperationEnd));
            Result<Address> addressResult = Address.New(
                request.Country, request.State, request.City, request.Street, request.AddressNumber, request.ZipCode);

            name = nameResult.Data;
            cnpj = cnpjResult.Data;
            email = emailResult.Data;
            address = addressResult.Data;
            operationStart = operationStartResult.Data;
            operationEnd = operationEndResult.Data;

            if(ResultHelpers.IsAnyFailed(nameResult, cnpjResult, emailResult, addressResult, operationStartResult, operationEndResult))
            {
                return ResultHelpers.FailWithMessages(nameResult, emailResult, cnpjResult, addressResult, operationStartResult, operationEndResult);
            }

            return Result.Success();
        }
    }
}