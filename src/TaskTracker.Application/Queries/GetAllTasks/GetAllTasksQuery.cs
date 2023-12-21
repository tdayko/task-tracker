using TaskTracker.Core.Domain;
using MediatR; 
namespace TaskTracker.Application.Queries.GetAllTasks;

public record GetAllTasksQuery() : IRequest<IEnumerable<TodoItem>>;