using MediatR;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Commands.AddTasks;

public record AddTaskCommand(TaskItem TaskItem) : IRequest<TaskItem>;
