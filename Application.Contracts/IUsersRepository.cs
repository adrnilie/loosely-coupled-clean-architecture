using Domain.Entities;

namespace Application.Contracts;

public interface IUsersRepository
{
    Task<IReadOnlyList<User>> GetUsers(CancellationToken cancellationToken = new());
    Task<Guid> CreateUser(User user, CancellationToken cancellationToken = new());
    Task<User?> GetUser(Guid id, CancellationToken cancellationToken = new());
    Task<User?> FindUser(string emailAddress, CancellationToken cancellationToken = new());
}