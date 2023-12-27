using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Application;
using TaskTracker.Application.Repository;
using TaskTracker.Console;
using TaskTracker.Core;
using TaskTracker.Core.Database;

var builderConfig = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .Build();

var services = new ServiceCollection();

services.AddCoreDbContext(builderConfig);

services.AddApplication();
services.AddSingleton<TaskManager>();
services.AddScoped<ITaskRepository, TaskRepository>();
ServiceProvider serviceProvider = services.BuildServiceProvider();

var userInterface = new UserInterface(serviceProvider.GetRequiredService<TaskManager>());

try
{
    await userInterface.RunAsync();
}
catch (Exception error)
{
    Console.WriteLine(error.Message);
    Console.WriteLine(error.StackTrace);
}
