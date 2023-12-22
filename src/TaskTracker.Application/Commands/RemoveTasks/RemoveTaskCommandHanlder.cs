using MediatR;
using TaskTracker.Application.Interfaces;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Commands.RemoveTasks;

public class RemoveTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<RemoveTaskCommand, TaskItem>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public Task<TaskItem> Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
        => _taskRepository.RemoveTask(request.Id);
}