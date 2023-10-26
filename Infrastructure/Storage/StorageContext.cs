using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Storage;

public sealed class StorageContext : DbContext, IStorageContext
{
    private readonly IConnectionStrings _connectionStrings;

    public StorageContext(DbContextOptions<StorageContext> options, IConnectionStrings connectionStrings)
        : base(options)
    {
        _connectionStrings = connectionStrings;
    }

    public DbSet<User> Users { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseInMemoryDatabase("db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(InfrastructureAssembly.Instance);
    }
}