using MassTransit;
using QuickOut.Application.Common;
using QuickOut.Intrastructure.Common;
using QuickOut.Library;

namespace QuickOut.Infrastructure.Common
{
    internal class EventBus : IVicthorEventBus
    {
        private readonly IPublishEndpoint publishEndpoint;
        public List<IDomainEvent> DomainEvents { get; set; } = new List<IDomainEvent>();

        public EventBus(IPublishEndpoint publishEndpoint)
        {
            this.publishEndpoint = publishEndpoint;
        }

        public async Task PublishIntegrationEvent<T>(T message) where T : class, IIntegrationEvent
        {
            await publishEndpoint.Publish(message, message.GetType());
        }

        public async Task PublishEventualConsistencyDomainEvent<T>(T message) where T : class, IDomainEvent
        {
            await publishEndpoint.Publish(message, message.GetType());
        }
    }
}
