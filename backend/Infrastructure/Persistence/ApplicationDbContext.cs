using Microsoft.EntityFrameworkCore;
using OsloOrbit.Domain.Forum;

namespace OsloOrbit.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Topic> Topics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configure your entities here
    }

    // Define DbSet properties for your entities
    // public DbSet<YourEntity> YourEntities { get; set; }
}