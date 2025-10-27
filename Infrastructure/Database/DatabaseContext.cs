using Microsoft.EntityFrameworkCore;
using MinimalApi.Domain.Entities;

namespace MinimalApi.Infrastructure.Database;

public class DatabaseContext : DbContext
{

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Admin> Admins { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>().HasData(
            new Admin
            {
                Id = 1,
                Email = "admin@test.com",
                Password = "1234567",
                Profile = "Admin"
            }
        );
    }

}