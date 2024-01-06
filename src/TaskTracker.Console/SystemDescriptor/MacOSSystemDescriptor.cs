using TaskTracker.Console.Interfaces;
namespace TaskTracker.Console.ValueObjects;

public class MacOSSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "MacOS";
    public string GetOSEmoji => "🍎";
}