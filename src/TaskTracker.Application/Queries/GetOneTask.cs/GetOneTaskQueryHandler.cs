using MediatR;

using TaskTracker.Application.Interfaces;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Queries.GetOneTask.cs;

public class GetOneTaskQueryHandler : IRequestHandler<GetOneTaskQuery, TodoItem>
{
    private readonly ITaskRepository _taskRepository;

    public GetOneTaskQueryHandler(ITaskRepository taskRepository)
        => _taskRepository = taskRepository;

    public async Task<TodoItem> Handle(GetOneTaskQuery request, CancellationToken cancellationToken)
        => await _taskRepository.GetOneTask(request.Id);
}