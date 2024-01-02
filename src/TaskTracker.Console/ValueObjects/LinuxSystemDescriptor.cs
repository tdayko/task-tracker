using TaskTracker.Application.Interfaces;

namespace TaskTracker.Console.ValueObjects;

public class LinuxSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "Linux";
    public string GetOSEmoji => "🐧";
}