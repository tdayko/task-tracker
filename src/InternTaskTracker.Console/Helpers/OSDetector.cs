using InternTaskTracker.Console.Interfaces;
using InternTaskTracker.Console.ValueObjects;

namespace InternTaskTracker.Console.Helpers;

public static class OSDetector
{
    public static ISystemDescriptor GetOSInfo()
    {
        return Environment.OSVersion.Platform switch
        {
            PlatformID.Win32NT => new WindowsSystemDescriptor(),
            PlatformID.Unix => new LinuxSystemDescriptor(),
            PlatformID.MacOSX => new MacOSSystemDescriptor(),
            _ => throw new Exception("Sistema operacional não identificado!") // tratar erro depois
        };
    }
}
