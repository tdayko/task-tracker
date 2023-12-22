using TaskTracker.Core.Domain;
using MediatR;

namespace TaskTracker.Application.Commands.RemoveTasks;

public record RemoveTaskCommand(int Id) : IRequest<TaskItem>;