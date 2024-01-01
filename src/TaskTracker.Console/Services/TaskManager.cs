using MediatR;

using TaskTracker.Application.Commands.AddTasks;
using TaskTracker.Application.Commands.RemoveTasks;
using TaskTracker.Application.Queries.GetAllTasks;
using TaskTracker.Application.Queries.GetOneTask.cs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Console.Services;

public class TaskManager(ISender mediator)
{
    private readonly ExtendedConsole _console = new(12);
    private readonly ISender _mediator = mediator;

    public async Task AddTask()
    {
        _console.Write("Enter task description: ");
        string description = Terminal.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(description))
        {
            _console.WriteLine("Invalid description. Please enter a valid description.");
            await AddTask();
            return;
        }

        try
        {
            await _mediator.Send(new AddTaskCommand(new TaskItem(description)));
            _console.WriteLine("Task added successfully!");
        }
        catch (Exception error)
        {
            _console.WriteLine(error.Message);
            _console.WriteLine(error.StackTrace);
        }
    }

    public async Task GetAllTasks()
    {
        try
        {
            IEnumerable<TaskItem> tasks = await _mediator.Send(new GetAllTasksQuery());
            Terminal.Clear();
            _console.WriteLine("Tasks:");
            foreach (TaskItem task in tasks)
            {
                _console.WriteLine($"Id: {task.Id} | Description: {task.Description} | IsComplete: {task.IsComplete}");
            }

            Terminal.ReadKey();
        }
        catch (Exception error)
        {
            _console.WriteLine(error.Message);
            _console.WriteLine(error.StackTrace);
        }
    }

    public async Task GetOneTask()
    {
        _console.Write("Enter task id: ");
        string id = Terminal.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(id))
        {
            _console.WriteLine("Invalid id. Please enter a valid id.");
            await GetOneTask();
            return;
        }

        try
        {
            TaskItem task = await _mediator.Send(new GetOneTaskQuery(int.Parse(id)));
            _console.WriteLine($"Id: {task.Id} | Description: {task.Description} | IsComplete: {task.IsComplete}");
        }
        catch (Exception error)
        {
            _console.WriteLine(error.Message);
            _console.WriteLine(error.StackTrace);
        }
    }

    public async Task RemoveTask()
    {
        _console.Write("Enter task id: ");
        string id = Terminal.ReadLine() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(id))
        {
            _console.WriteLine("Invalid id. Please enter a valid id.");
            await RemoveTask();
            return;
        }

        try
        {
            await _mediator.Send(new RemoveTaskCommand(int.Parse(id)));
            _console.WriteLine("Task removed successfully!");
        }
        catch (Exception error)
        {
            _console.WriteLine(error.Message);
            _console.WriteLine(error.StackTrace);
        }
    }
}