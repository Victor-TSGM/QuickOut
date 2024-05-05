using QuickOut.Application.Common;
using QuickOut.Library;

namespace QuickOut.Intrastructure.Common
{
    public interface IVicthorMediatorConfiguration
    {
        void Register<TRequest>(Type handlerType) where TRequest : IRequestBase;
        void RegisterTransactionalDomainEventHandler<TEvent>(Type handlerType) where TEvent : IDomainEvent;
    }
}