using MediatR;

using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Queries.GetOneTask.cs;

public record GetOneTaskQuery(int Id) : IRequest<TaskItem>;