namespace TaskTracker.Application.Commands.MarkTaskAsDone;

public record MarkTaskAsDoneCommand(int Id) : IRequest<TaskItem>;