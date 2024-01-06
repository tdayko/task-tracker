namespace TaskTracker.Console.SystemDescriptor;

public interface ISystemDescriptor
{
    string GetOSName { get; }
    string GetOSEmoji { get; }
}