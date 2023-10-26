using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts;

public interface IStorageContext
{
    DbSet<User> Users { get; }
    DbSet<OutboxMessage> OutboxMessages { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
}