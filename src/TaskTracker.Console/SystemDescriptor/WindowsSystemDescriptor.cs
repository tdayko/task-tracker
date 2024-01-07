using TaskTracker.Console.Interfaces;

namespace TaskTracker.Console.SystemDescriptor;

public class WindowsSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "Windows";
    public string GetOSEmoji => "🪟";
}