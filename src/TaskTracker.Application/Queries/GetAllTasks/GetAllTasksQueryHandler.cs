using MediatR;

using TaskTracker.Application.Interfaces;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Queries.GetAllTasks;

public class GetAllTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetAllTasksQuery, IEnumerable<TodoItem>>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<IEnumerable<TodoItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        => await _taskRepository.GetAllTasks();
}
