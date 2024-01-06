namespace TaskTracker.Console.Helpers;

public class WriteLineCentered(int baseTextWidth)
{
    public int BaseTextWidth { get; } = baseTextWidth;

    public void WriteLine(string text)
    {
        int leftMargin = (System.Console.WindowWidth / 2) - BaseTextWidth;

        System.Console.WriteLine(new string(' ', leftMargin) + text);
    }

    public void Write(string text)
    {
        int leftMargin = (System.Console.WindowWidth / 2) - BaseTextWidth;

        System.Console.Write(new string(' ', leftMargin) + text);
    }
}