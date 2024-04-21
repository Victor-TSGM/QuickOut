using QuickOut.Application.Common;
using QuickOut.Library;

namespace QuickOut.Infrastructure.Common;

public class DomainEventInfo : IDomainEventInfo
{
    public IDomainEvent DomainEvent { get; set; }
    public bool AllowEventualConsistency { get; set; }

    public DomainEventInfo(IDomainEvent domainEvent, bool allowEventualConsistency)
    {
        DomainEvent = domainEvent;
        AllowEventualConsistency = allowEventualConsistency;
    }
}

public class DomainEventManager : IDomainEventManager
{
    private readonly List<IDomainEventInfo> domainEvents = new List<IDomainEventInfo>();

    public void Add(IDomainEvent domainEvent, bool allowEventualConsistency = false)
    {
        lock (domainEvents)
        {
            domainEvents.Add(new DomainEventInfo(domainEvent, allowEventualConsistency));
        }
    }
    
    public void Remove(IDomainEventInfo domainEvent)
    {
        lock (domainEvents)
        {
            domainEvents.Remove(domainEvent);
        }
    }

    public List<IDomainEventInfo> GetPendingDomainEvents()
    {
        return domainEvents.ToList();
    }

    public bool HasPendingEvents() {
        return domainEvents.Count > 0;
    }
}