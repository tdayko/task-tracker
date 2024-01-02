using MediatR;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Commands.AddTasks;

public record MarkTaskAsDoneCommand(int Id) : IRequest<TaskItem>;