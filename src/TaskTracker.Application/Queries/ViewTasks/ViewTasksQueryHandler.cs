using MediatR;
using TaskTracker.Application.Interface;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Queries.ViewTasks;

public class ViewTasksQueryHandler(ITaskRepository taskRepository) : IRequestHandler<ViewTasksQuery, IEnumerable<TodoItem>>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<IEnumerable<TodoItem>> Handle(ViewTasksQuery request, CancellationToken cancellationToken)
        => await _taskRepository.ViewTasks();
}
