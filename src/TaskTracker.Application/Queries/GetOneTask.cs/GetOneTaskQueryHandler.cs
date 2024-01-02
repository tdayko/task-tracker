namespace TaskTracker.Application.Queries.GetOneTask.cs;

public class GetOneTaskQueryHandler : IRequestHandler<GetOneTaskQuery, TaskItem>
{
    private readonly ITaskRepository _taskRepository;

    public GetOneTaskQueryHandler(ITaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public async Task<TaskItem> Handle(GetOneTaskQuery request, CancellationToken cancellationToken)
    {
        return await _taskRepository.GetOneTask(request.Id);
    }
}