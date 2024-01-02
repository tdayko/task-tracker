using TaskTracker.Application.Interfaces;

namespace TaskTracker.Console.ValueObjects;

public class WindowsSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "Windows";
    public string GetOSEmoji => "🪟";
}