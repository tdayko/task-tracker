namespace TaskTracker.Domain.Entities;

public class TaskItem(string description, bool isComplete = false)
{
    public int? Id { get; set; }
    public string Description { get; set; } = description;
    public bool IsComplete { get; set; } = isComplete;
}