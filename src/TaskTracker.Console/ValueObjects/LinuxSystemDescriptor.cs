using TaskTracker.Console.Interfaces;
namespace TaskTracker.Console.ValueObjects;

public class LinuxSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "Linux";
    public string GetOSEmoji => "🐧";
}