namespace TaskTracker.Application.Commands.MarkTaskAsDone;

public class MarkTaskAsDoneCommandHandler : IRequestHandler<MarkTaskAsDoneCommand, TaskItem>
{
    private readonly ITaskRepository _taskItemRepository;

    public MarkTaskAsDoneCommandHandler(ITaskRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<TaskItem> Handle(MarkTaskAsDoneCommand request, CancellationToken cancellationToken)
    {
        TaskItem taskItem = await _taskItemRepository.GetOneTask(request.Id);
        taskItem.MarkComplete();

        await _taskItemRepository.UpdateTask(taskItem);
        return taskItem;
    }
}