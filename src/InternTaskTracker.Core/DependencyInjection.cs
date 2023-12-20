using InternTaskTracker.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InternTaskTracker.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlConnection");
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(connectionString));

        return services;
    }
}