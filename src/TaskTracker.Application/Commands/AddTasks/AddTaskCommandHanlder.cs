using MediatR;

using TaskTracker.Application.Interfaces;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Commands.AddTasks;

public class AddTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<AddTaskCommand>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    async Task IRequestHandler<AddTaskCommand>.Handle(AddTaskCommand request, CancellationToken cancellationToken)
        => await _taskRepository.AddTask(new TaskItem(request.Description));
}