using MediatR;

using TaskTracker.Application.Interfaces;

namespace TaskTracker.Application.Commands.RemoveTasks;

public class RemoveTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<RemoveTaskCommand>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    async Task IRequestHandler<RemoveTaskCommand>.Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
        => await _taskRepository.RemoveTask(request.Id);
    
}