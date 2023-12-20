using InternTaskTracker.Console.Helpers;
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

var oSInfo = OSDetector.GetOSInfo();

Console.WriteLine(oSInfo.GetOSEmoji + " Welcome to the Todo List App! " + oSInfo.GetOSEmoji);
Console.WriteLine("Your OS is: " + oSInfo.GetOSName);



