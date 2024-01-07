using TaskTracker.Application.Errors;
using TaskTracker.Application.Interfaces;
using MediatR;
using TaskTracker.Domain.Entities;
namespace TaskTracker.Application.Commands.AddTasks;

public class AddTaskCommandHandler(ITaskRepository taskRepository) : IRequestHandler<AddTaskCommand, TaskItem>
{
    private readonly ITaskRepository _taskRepository = taskRepository;

    public async Task<TaskItem> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        if (request.TaskItem.Description.Length > 25)
            throw new TaskDescriptionTooLongException();

        return await _taskRepository.AddTask(request.TaskItem);
    }
}