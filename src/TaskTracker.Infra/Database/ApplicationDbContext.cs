using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Infra.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<TaskItem>? TaskItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskItem>().HasKey(x => x.Id);
        modelBuilder.Entity<TaskItem>().HasKey(x => x.Id);
        modelBuilder.Entity<TaskItem>().Property(x => x.Id).ValueGeneratedOnAdd();
        modelBuilder.Entity<TaskItem>().Property(x => x.Description).IsRequired();
        modelBuilder.Entity<TaskItem>().Property(x => x.IsComplete).IsRequired();
    }
}