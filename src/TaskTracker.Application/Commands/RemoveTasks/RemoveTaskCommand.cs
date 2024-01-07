using MediatR;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Commands.RemoveTasks;

public record RemoveTaskCommand(int Id) : IRequest<TaskItem>;