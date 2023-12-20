using InternTaskTracker.Console.Interfaces;
namespace InternTaskTracker.Console.ValueObjects;

public class LinuxSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "Linux";
    public string GetOSEmoji => "\U0001F427";
}
