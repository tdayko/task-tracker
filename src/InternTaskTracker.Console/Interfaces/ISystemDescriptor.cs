namespace InternTaskTracker.Console.Interfaces;

public interface ISystemDescriptor
{
    string GetOSName { get; }
    string GetOSEmoji { get; }
}