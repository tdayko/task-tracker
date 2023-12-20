namespace InternTaskTracker.Console.Helpers;
using Terminal = System.Console;

public class ExtendedConsole(int baseTextWidth)
{
    public int BaseTextWidth { get; private set; } = baseTextWidth;
    public void WriteLine(string text)
    {
        int leftMargin = (Terminal.WindowWidth / 2) - BaseTextWidth;

        // Imprimir o texto com a margem esquerda calculada
        Terminal.WriteLine(new string(' ', leftMargin) + text);
    }

    public void Write(string text)
    {
        int leftMargin = (Terminal.WindowWidth / 2) - BaseTextWidth;

        // Imprimir o texto com a margem esquerda calculada
        Terminal.Write(new string(' ', leftMargin) + text);
    }
}
