using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Domain;

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
            var choiceRaw = Terminal.ReadLine() ?? string.Empty;
            _ = Enum.TryParse(choiceRaw, out TaskChoice choice);

            // await ChoiceHandler(choice);
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

    // private async Task ChoiceHandler(TodoChoice choice)
    // {
    //     switch (choice)
    //     {
    //         case TodoChoice.Add:
    //             await AddTaskAsync();
    //             break;
    //         case TodoChoice.Remove:
    //             await RemoveTaskAsync();
    //             break;
    //         case TodoChoice.MarkAsCompleted:
    //             await MarkTaskAsCompletedAsync();
    //             break;
    //         case TodoChoice.View:
    //             await ViewTasksAsync();
    //             break;
    //         case TodoChoice.Exit:
    //             Exit();
    //             break;
    //         default:
    //             _console.WriteLine("Invalid choice. Please try again.");
    //             break;
    //     }
    // }
}