namespace TaskTracker.Application.Interfaces;

public interface ISystemDescriptor
{
    string GetOSName { get; }
    string GetOSEmoji { get; }
}