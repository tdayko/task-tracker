using InternTaskTracker.Console.Interfaces;
namespace InternTaskTracker.Console.ValueObjects;

public class WindowsSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "Windows";
    public string GetOSEmoji => "Windows";
}
