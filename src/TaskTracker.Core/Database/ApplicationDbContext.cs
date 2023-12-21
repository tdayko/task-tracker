using Microsoft.EntityFrameworkCore;

using TaskTracker.Core.Domain;

namespace TaskTracker.Core.Database;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<TaskItem>? Todos { get; set; }
}