using MediatR;

using TaskTracker.Application.Interfaces;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Queries.GetAllTasks;

public class GetAllTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<GetAllTasksQuery, IEnumerable<TaskItem>>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<IEnumerable<TaskItem>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        => await _taskRepository.GetAllTasks();
}
