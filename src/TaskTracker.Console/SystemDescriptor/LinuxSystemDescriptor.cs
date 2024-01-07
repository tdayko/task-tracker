using TaskTracker.Console.Interfaces;
namespace TaskTracker.Console.SystemDescriptor;

public class LinuxSystemDescriptor : ISystemDescriptor
{
    public string GetOSName => "Linux";
    public string GetOSEmoji => "🐧";
}