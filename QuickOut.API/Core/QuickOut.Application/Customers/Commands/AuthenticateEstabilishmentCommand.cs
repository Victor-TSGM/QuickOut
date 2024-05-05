using QuickOut.Application.Common;
using QuickOut.Domain.Customers;
using QuickOut.DomainEvents;
using QuickOut.Library;

namespace QuickOut.Application.Customers;

public class AuthenticateEstabilishmentCommand : ICommand<string>
{
    public Guid CustomerId { get; set; }
    public string QRCode { get; set; }

    public AuthenticateEstabilishmentCommand(Guid customerId, string qrCode)
    {
        this.CustomerId = customerId;
        this.QRCode = qrCode;
    }
}

public class AuthenticateEstabilishmentCommandHandler : ICommandHandler<AuthenticateEstabilishmentCommand, string>
{
    private readonly ICustomerRepository repository;
    private readonly IDomainEventManager domainEvent;
    
    public AuthenticateEstabilishmentCommandHandler(ICustomerRepository repository, IDomainEventManager domainEvent)
    {
        this.repository = repository;
        this.domainEvent = domainEvent;
    }
    
    public Task<Result<string>> Handle(AuthenticateEstabilishmentCommand request)
    {   
        var domanEvent = new AuthenticateEstabilishmentEvent(request.QRCode, request.CustomerId);
        
        domainEvent.Add(domanEvent);
        
        return Result<string>.Success("Solicitação de autenticação enviada").AsTask();
    }
}