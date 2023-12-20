using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Console;

public class TaskTrackerApplication(DbContext context)
{
    private readonly ExtendedConsole _console = new(12);
    private readonly DbContext _context = context;
    private readonly ISystemDescriptor _systemDescriptor = OSDetector.GetOSInfo();

    public Task RunAsync()
    {
        while (true)
        {
            ShowMenu();
            // var choiceRaw = Console.ReadLine() ?? "";
            // _ = Enum.TryParse(choiceRaw, out TodoChoice choice);

            // await ChoiceHandler(choice);
            Terminal.Read();
        }
    }

    private void ShowMenu()
    {
        Terminal.Clear();
        _console.WriteLine(
            $"{_systemDescriptor.GetOSEmoji}  Welcome to the Todo List App! {_systemDescriptor.GetOSEmoji}\n");

        _console.WriteLine("===================================");
        _console.WriteLine($"Operacional System: {_systemDescriptor.GetOSName} {_systemDescriptor.GetOSEmoji}\n");
        _console.WriteLine("1. Add Task");
        _console.WriteLine("2. Remove Task");
        _console.WriteLine("3. Mark Task as Completed");
        _console.WriteLine("4. View Tasks");
        _console.WriteLine("5. Exit");
        _console.WriteLine("===================================\n");

        _console.Write("Enter your choice (1-5): ");
    }
}