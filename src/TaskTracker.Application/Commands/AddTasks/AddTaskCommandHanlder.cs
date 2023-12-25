using TaskTracker.Application.Interfaces;
using MediatR;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Commands.AddTasks;

public class AddTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<AddTaskCommand, TaskItem>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public Task<TaskItem> Handle(AddTaskCommand request, CancellationToken cancellationToken)
        => _taskRepository.AddTask(request.TaskItem);
}