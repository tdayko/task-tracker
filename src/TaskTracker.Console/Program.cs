using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Console;
using TaskTracker.Core;
using TaskTracker.Core.Database;

ServiceCollection services = new();
IConfigurationRoot builderConfig = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .Build();

services.AddCoreDbContext(builderConfig);
ServiceProvider serviceProvider = services.BuildServiceProvider();
ApplicationDbContext dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

TaskTrackerApplication application = new(dbContext);
await application.RunAsync();