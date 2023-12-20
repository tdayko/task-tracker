using MediatR;
namespace TaskTracker.Application.Commands.AddTasks;

public record AddTaskCommand(string Description) : IRequest;
