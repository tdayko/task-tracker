using MediatR;
using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Commands.AddTasks;

public record AddTaskCommand(string Description) : IRequest<TaskItem>;
