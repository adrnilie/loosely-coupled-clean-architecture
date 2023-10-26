using Domain.Primitives;

namespace Domain.Events;

public sealed record UserCreated(Guid Id, string FirstName, string LastName, string EmailAddress) : IOutboxEvent;