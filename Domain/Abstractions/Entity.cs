using Domain.Primitives;

namespace Domain.Abstractions;

public abstract class Entity : IEntity
{
    protected Entity(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; private set; }
}