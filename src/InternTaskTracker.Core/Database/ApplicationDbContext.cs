using InternTaskTracker.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace InternTaskTracker.Core.Database;

public class ApplicationDbContext : DbContext
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<TodoItem>? Todos { get; set; }
}