using CleanArchitect.Domain.Users;
using CleanArchitect.Infrastructure.Persistence.Configurations.Users;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitect.Infrastructure.Persistence;

public class CleanDbContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;

    public CleanDbContext(DbContextOptions<CleanDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("User", "Users");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
