using MediatR;

using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Commands.AddTasks;

public class MarkTaskAsDoneCommandHandler : IRequestHandler<MarkTaskAsDoneCommand, TaskItem>
{
    private readonly ITaskRepository _taskItemRepository;

    public MarkTaskAsDoneCommandHandler(ITaskRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }

    public async Task<TaskItem> Handle(MarkTaskAsDoneCommand request, CancellationToken cancellationToken)
    {
        var taskItem = await _taskItemRepository.GetOneTask(request.Id);
        taskItem.MarkComplete();
        
        await _taskItemRepository.UpdateTask(taskItem);
        return taskItem;
    }
}