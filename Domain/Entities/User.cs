using Domain.Abstractions;
using Domain.Events;

namespace Domain.Entities;

public sealed class User : AggregateRoot
{
    public User(Guid id) : base(id)
    {
    }

    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string EmailAddress { get; private set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";

    public static User Create(string firstName, string lastName, string emailAddress)
    {
        var user = new User(Guid.NewGuid()) { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress};

        user.RaiseEvent(new UserCreated(
            user.Id,
            user.FirstName,
            user.LastName,
            user.EmailAddress));

        return user;
    }
}