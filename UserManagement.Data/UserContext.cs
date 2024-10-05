using DateEntry.Data.Entities;
using Microsoft.EntityFrameworkCore;

public class UserContext : DbContext
{
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserType>().HasData(
            new UserType { Id = 1, Name = "Admin" },
            new UserType { Id = 2, Name = "Moderator" }
        );

        // Seeding a test admin user (use a hashed password for real cases)
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                FirstName = "Ahmed",
                LastName = "Sakr",
                Email = "Ahmed.Sakr@Admin.com",
                Password = "Admin@123", 
                PhoneNumber = "(123) 456-7890",
                UserTypeId = 1, // Admin
                Address = "123 Maadi Street",
                ZipCode = "12345"
            }
        );
        // Seeding a test admin user (use a hashed password for real cases)
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 2,
                FirstName = "Aser",
                LastName = "Ahmed",
                Email = "Aser.Ahmed@Moderator.com",
                Password = "Moderator@123",
                PhoneNumber = "(456) 456-7890",
                UserTypeId = 2, // Moderator
                Address = "123 Maadi Street",
                ZipCode = "12345"
            }
        );
    }
    public DbSet<User> Users { get; set; }
    public virtual DbSet<UserType> UserTypes { get; set; }

}
