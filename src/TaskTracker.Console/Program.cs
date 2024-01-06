using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TaskTracker.Console;
using TaskTracker.Console.TaskClient;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .Build();

ServiceCollection services = new();
services.AddRestClient(new Uri(configuration["ApiUrl"]!));
services.AddSingleton<ITaskClient,TaskClient>();
ServiceProvider serviceProvider = services.BuildServiceProvider();

UserInterface userInterface = new(serviceProvider.GetRequiredService<ITaskClient>());

try
{
    await userInterface.RunAsync();
}
catch (Exception error)
{
    Console.WriteLine(error.Message);
    Console.WriteLine(error.StackTrace);
}