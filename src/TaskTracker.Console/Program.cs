using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskTracker.Application;
using TaskTracker.Console;
using TaskTracker.Console.Services;
using TaskTracker.Infra;
using TaskTracker.Infra.Repository;

IConfigurationRoot builderConfig = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .AddUserSecrets<Program>()
    .Build();

ServiceCollection services = new ServiceCollection();


services.AddApplication();
services.AddSingleton<TaskManager>();
services.AddScoped<ITaskRepository, TaskRepository>();
services.AddCoreDbContext(builderConfig);
ServiceProvider serviceProvider = services.BuildServiceProvider();

UserInterface userInterface = new UserInterface(serviceProvider.GetRequiredService<TaskManager>());

try
{
    await userInterface.RunAsync();
}
catch (Exception error)
{
    Console.WriteLine(error.Message);
    Console.WriteLine(error.StackTrace);
}