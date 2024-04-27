using Microsoft.Extensions.DependencyInjection;
using QuickOut.Application.Common;
using QuickOut.Intrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Infrastructure.Common;

public class VicthorMediatorConfiguration : IVicthorMediatorConfiguration
{
    private readonly IServiceCollection _services;

    public Dictionary<Type, Type> RequestHandlers { get; private set; } = new();
    public Dictionary<Type, List<Type>> TransactionalEventHandlers { get; private set; } = new();

    public VicthorMediatorConfiguration(IServiceCollection services)
    {
        this._services = services;
    }

    public void Register<TRequest>(Type handlerType) where TRequest : IRequestBase
    {
        _services.AddScoped(handlerType);

        if (RequestHandlers.ContainsKey(typeof(TRequest)))
        {
            RequestHandlers[typeof(TRequest)] = handlerType;
        }else
        {
            RequestHandlers.Add(typeof(TRequest), handlerType);
        }
    }

    public void RegisterTransactionalDomainEventHandler<TEvent>(Type handlerType) where TEvent : IDomainEvent
    {
        _services.AddScoped(handlerType);

        if (TransactionalEventHandlers.ContainsKey(typeof(TEvent)))
        {
            TransactionalEventHandlers[typeof(TEvent)].Add(handlerType);
        } else
        {
            TransactionalEventHandlers.Add(typeof(TEvent), new List<Type>()
            {
                handlerType
            });
        }
    }
}

