
using MediatR;
using TaskTracker.Core.Domain;
namespace TaskTracker.Application.Queries.ViewTasks;

public record ViewTasksQuery() : IRequest<IEnumerable<TodoItem>>;