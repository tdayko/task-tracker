using InternTaskTracker.Console;
using InternTaskTracker.Core;
using InternTaskTracker.Core.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var builderConfig = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true, true)
    .Build();

services.AddCoreDbContext(builderConfig);
var serviceProvider = services.BuildServiceProvider();
var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

var application = new TaskTrackerApplication(dbContext);
await application.RunAsync();





