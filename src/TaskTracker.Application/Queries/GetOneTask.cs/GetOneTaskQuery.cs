using TaskTracker.Core.Domain;
namespace TaskTracker.Application.Queries.GetOneTask.cs;

public record GetOneTaskQuery(int Id) : MediatR.IRequest<TaskItem>;