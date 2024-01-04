using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using TaskTracker.Console;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, true)
    .AddUserSecrets<Program>()
    .Build();

ServiceCollection services = new();
services.AddRestClient(new Uri(configuration["ApiUrl"]!));
services.AddSingleton<TaskService>();
ServiceProvider serviceProvider = services.BuildServiceProvider();

UserInterface userInterface = new(serviceProvider.GetRequiredService<TaskService>());

try
{
    await userInterface.RunAsync();
}
catch (Exception error)
{
    Console.WriteLine(error.Message);
    Console.WriteLine(error.StackTrace);
}