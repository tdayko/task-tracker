using MediatR;
using TaskTracker.Application.Errors;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Queries.GetAllTasks;

public class GetAllTasksQueryHandler(ITaskRepository taskRepository)
    : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItem>>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<TaskItem>? tasks = await _taskRepository.GetAllTasks();
        return !tasks.Any() ? throw new NoTaskFoundException() : tasks;
    }
}