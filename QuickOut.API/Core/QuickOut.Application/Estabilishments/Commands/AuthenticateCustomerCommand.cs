using QuickOut.Application.Common;
using QuickOut.Domain.Estabilishments;
using QuickOut.DomainEvents;
using QuickOut.Library;

namespace QuickOut.Application.Estabilishments;

public class AuthenticateCustomerCommand: ICommand<Guid>
{
    public string Code { get; set; }
    public Guid CustomerId { get; set; }
    public AuthenticateCustomerCommand(string code, Guid customerId)
    {
        Code = code;
        CustomerId = customerId;
    }
}

public class AuthenticateCustomerCommandHandler : ICommandHandler<AuthenticateCustomerCommand, Guid>
{
    private readonly IEstabilishmentRepository repository;
    private readonly IDomainEventManager domainEvent;

    public AuthenticateCustomerCommandHandler(IEstabilishmentRepository repository, IDomainEventManager domainEvent)
    {
        this.repository = repository;
        this.domainEvent = domainEvent;
    }
    
    public async Task<Result<Guid>> Handle(AuthenticateCustomerCommand request)
    {
        Estabilishment? dbEntity = await repository.ValidateAuthenticationCode(request.Code);

        if (dbEntity == null)
        {
            return Result<Guid>.Fail("Não existe estabelecimentos com esse código");
        }

        Result<EstabilishmentSection> startSection = EstabilishmentSection.StartSection(request.CustomerId, dbEntity);

        if (!startSection.Succeeded)
        {
            return Result<Guid>.Fail("Não foi possível iniciar uma sessão");
        }
        
        domainEvent.Add(new AuthenticateCustomerEvent(dbEntity.Id, request.CustomerId));
        
        dbEntity.AddSection(startSection.Data);
        
        repository.AddSection(dbEntity);

        return Result<Guid>.Success(dbEntity.Id);
    }
}