using MediatR;

using TaskTracker.Application.Errors;
using TaskTracker.Application.Repositories;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Commands.RemoveTasks;

public class RemoveTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<RemoveTaskCommand, TaskItem>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<TaskItem> Handle(RemoveTaskCommand request, CancellationToken cancellationToken)
    {
        _ = await _taskRepository.GetOneTask(request.Id) ?? throw new IdGivenTaskNotFoundException();
        return await _taskRepository.RemoveTask(request.Id);
    }
}