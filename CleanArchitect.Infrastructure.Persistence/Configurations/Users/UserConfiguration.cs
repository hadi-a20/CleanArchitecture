using CleanArchitect.Domain.Common.Models;
using CleanArchitect.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitect.Infrastructure.Persistence.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(c => c.Id);

        ConfigureProperties(builder);
        ConfigureIndexes(builder);
    }

    private static void ConfigureProperties(EntityTypeBuilder<User> builder)
    {
        builder.Property(c => c.Id)
            .HasColumnName("Id")
            .HasConversion(id => id.Value, value => Id.Create(value))
            .ValueGeneratedOnAdd();

        builder.Property(c => c.FirstName)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(320)
            .IsRequired();

        builder.Property(c => c.Password)
               .HasMaxLength(50)
               .IsRequired();
    }

    private static void ConfigureIndexes(EntityTypeBuilder<User> builder)
    {
        builder.HasIndex(c => c.Email, "IX_Email")
            .IsUnique();
    }
}
