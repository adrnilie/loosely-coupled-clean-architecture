namespace Application.Contracts.Commands;

public sealed record CreateNewUser(string FirstName, string LastName, string EmailAddress);