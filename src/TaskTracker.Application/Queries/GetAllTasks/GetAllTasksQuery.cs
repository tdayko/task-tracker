using MediatR;

using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Queries.GetAllTasks;

public record GetAllTasksQuery : IRequest<IEnumerable<TaskItem>>;