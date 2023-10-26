using Domain.Primitives;

namespace Domain.Abstractions;

public abstract class AggregateRoot : Entity
{
    private readonly List<IOutboxEvent> _outboxEvents = new();

    protected AggregateRoot(Guid id)
        :base(id)
    {
        
    }

    protected void RaiseEvent(IOutboxEvent @event)
    {
        _outboxEvents.Add(@event);
    }
}