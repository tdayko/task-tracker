using MediatR;

using Microsoft.AspNetCore.Mvc;

using TaskTracker.Application.Commands.AddTasks;
using TaskTracker.Application.Commands.MarkTaskAsDone;
using TaskTracker.Application.Commands.RemoveTasks;
using TaskTracker.Application.Queries.GetAllTasks;
using TaskTracker.Application.Queries.GetOneTask.cs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Api.Controllers;

[ApiController]
[Route("task-tracker/api/")]
public class TaskController(IMediator mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    [HttpGet("tasks")]
    public async Task<IActionResult> GetAllTasks()
    {
        IEnumerable<TaskItem> tasks = await _mediator.Send(new GetAllTasksQuery());
        return Ok(tasks);
    }

    [HttpGet("tasks/{id}")]
    public async Task<IActionResult> GetOneTask(int id)
    {
        TaskItem task = await _mediator.Send(new GetOneTaskQuery(id));
        return Ok(task);
    }

    [HttpPost("tasks")]
    public async Task<IActionResult> AddTask(TaskItem taskItem)
    {
        TaskItem task = await _mediator.Send(new AddTaskCommand(taskItem));
        return Ok(task);
    }

    [HttpDelete("tasks/{id}")]
    public async Task<IActionResult> RemoveTask(int id)
    {
        TaskItem task = await _mediator.Send(new RemoveTaskCommand(id));
        return Ok();
    }

[HttpPut("tasks/mark-task-as-done/{id}")]
    public async Task<IActionResult> MarkTaskAsDone(int id)
    {
        TaskItem task = await _mediator.Send(new MarkTaskAsDoneCommand(id));
        return Ok(task);
    }
}