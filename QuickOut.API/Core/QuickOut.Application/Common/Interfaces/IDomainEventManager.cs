using QuickOut.Application.Common;

public interface IDomainEventInfo {
    public IDomainEvent DomainEvent { get; set; }
    public bool AllowEventualConsistency { get; set; }
}

public interface IDomainEventManager
{
    List<IDomainEventInfo> GetPendingDomainEvents();
    bool HasPendingEvents();

    void Add(IDomainEvent domainEvent, bool allowEventualConsistency = false);
    void Remove(IDomainEventInfo domainEvent);
}