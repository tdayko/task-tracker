namespace TaskTracker.Console.Helpers;

public class ExtendedConsole(int baseTextWidth)
{
    public int BaseTextWidth { get; } = baseTextWidth;

    public void WriteLine(string text)
    {
        int leftMargin = (Terminal.WindowWidth / 2) - BaseTextWidth;

        Terminal.WriteLine(new string(' ', leftMargin) + text);
    }

    public void Write(string text)
    {
        int leftMargin = (Terminal.WindowWidth / 2) - BaseTextWidth;

        Terminal.Write(new string(' ', leftMargin) + text);
    }
}