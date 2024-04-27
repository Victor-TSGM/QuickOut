using QuickOut.Application.Common;
using QuickOut.Library;

namespace QuickOut.Intrastructure.Common
{
    public interface IVicthorEventBus
    {
        Task PublishIntegrationEvent<T>(T message) where T : class, IIntegrationEvent;
        Task PublishEventualConsistencyDomainEvent<T>(T message) where T : class, IDomainEvent;
    }
}