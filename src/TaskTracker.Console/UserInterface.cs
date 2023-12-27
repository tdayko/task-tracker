using Microsoft.EntityFrameworkCore;
using TaskTracker.Core.Domain;

namespace TaskTracker.Console;
public class UserInterface(TaskManager taskManager)
{
    private readonly ExtendedConsole _console = new(12);
    private readonly ISystemDescriptor _systemDescriptor = OSDetector.GetOSInfo();
    private readonly TaskManager _taskManager = taskManager;

    public async Task RunAsync()
    {
        while (true)
        {
            ShowMenu();
            var choiceRaw = Terminal.ReadLine() ?? string.Empty;
            _ = Enum.TryParse(choiceRaw, out TaskChoice choice);

            await ChoiceHanler(choice);
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

    private async Task ChoiceHanler(TaskChoice choice)
    {
        switch (choice)
        {
            case TaskChoice.Add:
                await _taskManager.AddTask();
                break;
            case TaskChoice.View:
                await _taskManager.GetAllTasks();
                break;
            case TaskChoice.Remove:
                await _taskManager.RemoveTask();
                break;
            default:
                _console.WriteLine("Invalid choice. Please enter a valid choice.");
                break;
        }
    }
}