using MediatR;
using TaskTracker.Core.Domain;
using TaskTracker.Application.Interface;

namespace TaskTracker.Application.Commands.AddTasks;

public class AddTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<AddTaskCommand>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    async Task IRequestHandler<AddTaskCommand>.Handle(AddTaskCommand request, CancellationToken cancellationToken)
        => await _taskRepository.AddTask(new TodoItem(request.Description));
}