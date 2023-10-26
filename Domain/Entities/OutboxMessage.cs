using Domain.Abstractions;

namespace Domain.Entities;

public sealed class OutboxMessage : Entity
{
    public OutboxMessage(Guid id) : base(id)
    {
    }

    public string Type { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime OccurredOnUtc { get; set; }
    public DateTime? ProcessedOnUtc { get; set; }
    public string? Error { get; set; }
}