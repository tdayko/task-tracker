using InternTaskTracker.Console.Interfaces;
namespace InternTaskTracker.Console.ValueObjects;

public class MacOSSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "MacOS";
    public string GetOSEmoji => "MacOS";
}
