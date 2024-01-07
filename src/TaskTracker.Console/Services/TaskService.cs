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
        await _mediator.Send(new AddTaskCommand(task));
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        IEnumerable<TaskItem> tasks = await _mediator.Send(new GetAllTasksQuery());
        return tasks.OrderBy(task => task.Id);
    }

    public async Task<TaskItem> GetOneTask(int id)
    {
        return await _mediator.Send(new GetOneTaskQuery(id));
    }

    public async Task RemoveTask(int id)
    {
        await _mediator.Send(new RemoveTaskCommand(id));
    }

    public async Task MarkTaskAsDone(int id)
    {
        await _mediator.Send(new MarkTaskAsDoneCommand(id));
    }
}