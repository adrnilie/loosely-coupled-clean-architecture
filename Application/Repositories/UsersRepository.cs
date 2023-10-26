using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Repositories;

internal sealed class UsersRepository : IUsersRepository
{
    private readonly IStorageContext _context;

    public UsersRepository(IStorageContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<User>> GetUsers(CancellationToken cancellationToken = new())
    {
        var users = await _context
            .Users
            .ToListAsync(cancellationToken);

        return users;
    }

    public async Task<Guid> CreateUser(User user, CancellationToken cancellationToken = new())
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user.Id;
    }

    public async Task<User?> GetUser(Guid id, CancellationToken cancellationToken = new())
    {
        var user = await _context
            .Users
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        return user;
    }

    public async Task<User?> FindUser(string emailAddress, CancellationToken cancellationToken = new())
    {
        var user = await _context
            .Users
            .SingleOrDefaultAsync(x => x.EmailAddress == emailAddress, cancellationToken);

        return user;
    }
}