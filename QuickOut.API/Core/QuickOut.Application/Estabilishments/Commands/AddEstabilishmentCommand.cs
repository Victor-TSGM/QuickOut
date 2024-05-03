using QuickOut.Application.Common;
using QuickOut.Domain.Common;
using QuickOut.Domain.Estabilishments;
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
        public string PostalCode { get; set; }

        public AddEstabilishmentCommand(string name, string cnpj, string email, double operationStart, double operationEnd, string country, string state, string city, string street, int addressNumber, string postalCode)
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
            PostalCode = postalCode;
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
            string cnpj;
            string email;
            TimeSpan operationStart;
            TimeSpan operationEnd;

            Result result = TryParseInput(request, out name, out cnpj, out email, out operationStart, out operationEnd);

            if(!result.Succeeded)
            {
                return Result<Guid>.Fail(result.Messages);
            }

            Address address = new Address
            {
                Country = request.Country,
                State = request.State,
                Street = request.Street,
                City = request.City,
                AddressNumber = request.AddressNumber,
                PostalCode = request.PostalCode
            };

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
            out string cnpj, 
            out string email,
            out TimeSpan operationStart, 
            out TimeSpan operationEnd)
        {
            Result<string> nameResult = Result<string>.Success(request.Name);
            Result<string> cnpjResult = Result<string>.Success(request.CNPJ);
            Result<string> emailResult = Result<string>.Success(request.Email);
            Result<TimeSpan> operationStartResult = Result<TimeSpan>.Success(TimeSpan.FromMilliseconds(request.OperationStart));
            Result<TimeSpan> operationEndResult = Result<TimeSpan>.Success(TimeSpan.FromMilliseconds(request.OperationEnd));

            name = nameResult.Data;
            cnpj = cnpjResult.Data;
            email = emailResult.Data;
            operationStart = operationStartResult.Data;
            operationEnd = operationEndResult.Data;

            if(ResultHelpers.IsAnyFailed(nameResult, cnpjResult, emailResult, operationStartResult, operationEndResult))
            {
                return ResultHelpers.FailWithMessages(nameResult, emailResult, cnpjResult, operationStartResult, operationEndResult);
            }

            return Result.Success();
        }
    }
}