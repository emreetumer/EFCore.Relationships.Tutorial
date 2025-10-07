using EFCore_Relationships.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Relationships.WebAPI.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<UserInformation> UsersInformation { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(p => p.UserInformation)
            .WithOne()
            .HasForeignKey<User>(p => p.UserInformationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
