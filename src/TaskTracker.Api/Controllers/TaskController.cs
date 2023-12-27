using MediatR;

using Microsoft.AspNetCore.Mvc;

using TaskTracker.Application.Commands.AddTasks;
using TaskTracker.Application.Commands.RemoveTasks;
using TaskTracker.Application.Queries.GetAllTasks;
using TaskTracker.Application.Queries.GetOneTask.cs;
using TaskTracker.Core.Domain;

namespace TaskTracker.Api.Controllers;

[ApiController]
[Route("task-tracker/api/")]
public class TaskController(IMediator mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator;

    [HttpGet("tasks")]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await _mediator.Send(new GetAllTasksQuery());
        return Ok(tasks);
    }

    [HttpGet("tasks/{id}")]
    public async Task<IActionResult> GetOneTask(int id)
    {
        var task = await _mediator.Send(new GetOneTaskQuery(id));
        return Ok(task);
    }

    [HttpPost("tasks")]
    public async Task<IActionResult> AddTask(TaskItem taskItem)
    {
        var task = await _mediator.Send(new AddTaskCommand(taskItem));
        return Ok(task);
    }

    [HttpDelete("tasks/{id}")]
    public async Task<IActionResult> RemoveTask(int id)
    {
        var task = await _mediator.Send(new RemoveTaskCommand(id));
        return Ok(task);
    }
}