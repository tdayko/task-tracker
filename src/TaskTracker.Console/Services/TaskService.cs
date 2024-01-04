using MediatR;

using TaskTracker.Application.Commands.AddTasks;
using TaskTracker.Application.Commands.MarkTaskAsDone;
using TaskTracker.Application.Commands.RemoveTasks;
using TaskTracker.Application.Queries.GetAllTasks;
using TaskTracker.Application.Queries.GetOneTask.cs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Console.Services;

public class TaskService(ISender mediator)
{
    private readonly ISender _mediator = mediator;

    public async Task AddTask(TaskItem task)
    {
        try
        {
            await _mediator.Send(new AddTaskCommand(task));
        }
        catch (Exception error)
        {
            Terminal.WriteLine(error.Message);
            Terminal.WriteLine(error.StackTrace);
        }
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        try
        {
            IEnumerable<TaskItem> tasks = await _mediator.Send(new GetAllTasksQuery());
            return tasks.OrderBy(task => task.Id);
        }
        catch (Exception error)
        {
            Terminal.WriteLine(error.Message);
            Terminal.WriteLine(error.StackTrace);
            return Enumerable.Empty<TaskItem>();
        }
    }

    public async Task GetOneTask(int id)
    {
        try
        {
            TaskItem task = await _mediator.Send(new GetOneTaskQuery(id));
        }
        catch (Exception error)
        {
            Terminal.WriteLine(error.Message);
            Terminal.WriteLine(error.StackTrace);
        }
    }

    public async Task RemoveTask(int id)
    {
        try
        {
            await _mediator.Send(new RemoveTaskCommand(id));
        }
        catch (Exception error)
        {
            Terminal.WriteLine(error.Message);
            Terminal.WriteLine(error.StackTrace);
        }
    }

    public async Task MarkTaskAsDone(int id)
    {
        try
        {
            await _mediator.Send(new MarkTaskAsDoneCommand(id));
        }
        catch (Exception error)
        {
            Terminal.WriteLine(error.Message);
            Terminal.WriteLine(error.StackTrace);
        }
    }
}