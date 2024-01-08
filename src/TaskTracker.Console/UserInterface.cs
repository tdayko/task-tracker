using TaskTracker.Console.Helpers;
using TaskTracker.Console.SystemDescriptor;
using TaskTracker.Console.TaskClient;
using TaskTracker.Domain.Entities;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Console;

public class UserInterface(ITaskClient taskClient)
{
    private readonly WriteLineCentered _menuWidthWriter = new(12);
    private readonly WriteLineCentered _showTasksWriter = new(16);
    private readonly ISystemDescriptor _systemDescriptor = OSDetector.GetOSInfo();
    private readonly ITaskClient _taskClient = taskClient;

    public async Task RunAsync()
    {
        while (true)
        {
            ShowMenu();
            string choiceRaw = System.Console.ReadLine() ?? string.Empty;
            _ = Enum.TryParse(choiceRaw, out TaskChoice choice);

            await ChoiceHanler(choice);
        }
    }

    private async Task ChoiceHanler(TaskChoice choice)
    {
        switch (choice)
        {
            case TaskChoice.Add:
                AddTask();
                break;
            case TaskChoice.View:
                await ViewTasks();
                break;
            case TaskChoice.Remove:
                await RemoveTask();
                break;
            case TaskChoice.MarkAsDone:
                await MarkTaskAsDone();
                break;
            case TaskChoice.Exit:
                Exit();
                break;
            default:
                _menuWidthWriter.WriteLine("Invalid choice. Please enter a valid choice.");
                break;
        }
    }

    private void ShowMenu()
    {
        System.Console.Clear();
        _menuWidthWriter.WriteLine(
            $"{_systemDescriptor.GetOSEmoji}  Welcome to the Todo List App! {_systemDescriptor.GetOSEmoji}\n");

        _menuWidthWriter.WriteLine("===================================");
        _menuWidthWriter.WriteLine(
            $"Operacional System: {_systemDescriptor.GetOSName} {_systemDescriptor.GetOSEmoji}\n");
        _menuWidthWriter.WriteLine("1. Add Task");
        _menuWidthWriter.WriteLine("2. Remove Task");
        _menuWidthWriter.WriteLine("3. Mark Task as Completed");
        _menuWidthWriter.WriteLine("4. View Tasks");
        _menuWidthWriter.WriteLine("5. Exit");
        _menuWidthWriter.WriteLine("===================================\n");

        _menuWidthWriter.Write("Enter your choice (1-5): ");
    }

    private async void AddTask()
    {
        _menuWidthWriter.Write("Enter task description: ");
        string description = System.Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(description))
        {
            _menuWidthWriter.WriteLine("Invalid description. Please enter a valid description.");
            AddTask();
            return;
        }

        try
        {
            await _taskClient.AddTask(new TaskItem(description));
            System.Console.WriteLine("");
            _menuWidthWriter.WriteLine("Task added successfully!");
            _menuWidthWriter.Write("Press any key to continue...");
            System.Console.ReadKey();
        }
        catch
        {
            _menuWidthWriter.WriteLine("An error occurred while trying to add your task.");
            _menuWidthWriter.WriteLine("Press any key to conti");
        }
    }

    private async Task MarkTaskAsDone()
    {
        _menuWidthWriter.Write("Enter task id: ");
        string id = System.Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(id))
        {
            _menuWidthWriter.WriteLine("Invalid id. Please enter a valid id.");
            await MarkTaskAsDone();
            return;
        }

        try
        {
            await _taskClient.MarkTaskAsDone(int.Parse(id));
            _menuWidthWriter.WriteLine("Task marked as done successfully!");
            _menuWidthWriter.Write("Press any key to continue...");
            System.Console.ReadKey();
        }
        catch
        {
            _menuWidthWriter.WriteLine("An error occurred while trying to mark your task as done.");
            _menuWidthWriter.WriteLine("Press any key to conti");
        }
    }

    private async Task ViewTasks()
    {
        try
        {
            IEnumerable<TaskItem> tasks = await _taskClient.GetAllTasks();

            if (!tasks.Any())
            {
                _menuWidthWriter.WriteLine("You have no tasks.");
                _showTasksWriter.Write("Press any key to continue...");
                System.Console.ReadKey();
                return;
            }

            System.Console.Clear();
            _showTasksWriter.WriteLine("You have the following tasks:");
            _showTasksWriter.WriteLine("=================================================\n");
            foreach (TaskItem task in tasks)
            {
                _showTasksWriter.WriteLine($"Id: {task.Id}");
                _showTasksWriter.WriteLine($"Description: {task.Description}");
                _showTasksWriter.WriteLine($"IsComplete: {task.IsComplete}");
                _showTasksWriter.WriteLine("=================================================\n");
            }

            _showTasksWriter.Write("Press any key to continue...");
            System.Console.ReadKey();
        }
        catch
        {
            _menuWidthWriter.WriteLine("An error occurred while trying to get your tasks.");
            _menuWidthWriter.WriteLine("Press any key to continue...");
            Exit();
        }
    }

    private async Task RemoveTask()
    {
        _menuWidthWriter.Write("Enter task id: ");
        string id = System.Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(id))
        {
            _menuWidthWriter.WriteLine("Invalid id. Please enter a valid id.");
            await _taskClient.RemoveTask(int.Parse(id));
            return;
        }

        try
        {
            await _taskClient.RemoveTask(int.Parse(id));
            _menuWidthWriter.WriteLine("Task removed successfully!");
            _menuWidthWriter.Write("Press any key to continue...");
            System.Console.ReadKey();
        }
        catch
        {
            _menuWidthWriter.WriteLine("An error occurred while trying to remove your task.");
            _menuWidthWriter.WriteLine("Press any key to continue...");
        }
    }

    private void Exit()
    {
        _menuWidthWriter.WriteLine("Thank you for using the Todo List App!");
        System.Console.Clear();
        Environment.Exit(0);
    }
}