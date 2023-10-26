using Application.Contracts;

namespace Application.Settings;

internal sealed class ConnectionStrings : IConnectionStrings
{
    public const string SectionPath = "ConnectionStrings";

    public string Storage { get; init; }
}