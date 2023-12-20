using InternTaskTracker.Console;
using InternTaskTracker.Core;
using InternTaskTracker.Core.Database;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

ServiceCollection services = new ServiceCollection();
IConfigurationRoot builderConfig = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .Build();

services.AddCoreDbContext(builderConfig);
ServiceProvider serviceProvider = services.BuildServiceProvider();
ApplicationDbContext dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

TaskTrackerApplication application = new TaskTrackerApplication(dbContext);
await application.RunAsync();