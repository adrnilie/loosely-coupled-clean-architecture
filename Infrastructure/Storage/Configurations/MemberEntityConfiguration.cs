using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Storage.Configurations;

public sealed class MemberEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Ignore(x => x.FullName);

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(x => x.EmailAddress)
            .HasMaxLength(150)
            .IsRequired();

        builder
            .HasIndex(x => x.EmailAddress)
            .IsUnique();
    }
}