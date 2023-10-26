using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Configurations;

public sealed class OutboxMessageEntityConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Type)
            .IsRequired();

        builder
            .Property(x => x.OccurredOnUtc)
            .IsRequired();

        builder
            .Property(x => x.ProcessedOnUtc);

        builder
            .Property(x => x.Content)
            .IsRequired();

        builder
            .Property(x => x.Error);
    }
}