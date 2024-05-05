using System.Windows.Input;
using QuickOut.Application.Common;
using QuickOut.Domain.Customers;
using QuickOut.Library;

namespace QuickOut.Application.Customers;

public class StartSectionCommand : ICommand<Guid>
{
    public Guid EstabilishmentId { get; set; }
    public Guid CustomerId { get; set; }

    public StartSectionCommand(Guid estabilishmentId, Guid customerId)
    {
        this.EstabilishmentId = estabilishmentId;
        this.CustomerId = customerId;
    }
}

public class StartSectionCommandHandler : ICommandHandler<StartSectionCommand, Guid>
{
    private readonly ICustomerRepository repository;
    private readonly IDomainEventManager domainEvent;
    
    public StartSectionCommandHandler(ICustomerRepository repository, IDomainEventManager domainEvent)
    {
        this.repository = repository;
        this.domainEvent = domainEvent;
    }

    public async Task<Result<Guid>> Handle(StartSectionCommand request)
    {
        Customer? dbEntity = await repository.GetById(request.CustomerId);

        if (dbEntity == null)
        {
            return Result<Guid>.Fail("Cliente não encontrado");
        }

        Result<CustomerSection> startSection = CustomerSection.StartSection(request.EstabilishmentId ,dbEntity);

        if (!startSection.Succeeded)
        {
            return Result<Guid>.Fail("Não foi possível iniciar a sessão");
        }
        
        dbEntity.AddSection(startSection.Data);
        
        repository.AddSection(dbEntity);
        
        //domainEvent.Add(new CustomerSectionStarted());
        
        return Result<Guid>.Success(dbEntity.Id);
    }
}