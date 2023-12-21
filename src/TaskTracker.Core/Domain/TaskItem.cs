namespace TaskTracker.Core.Domain;

public class TaskItem(string description, bool isComplete = false)
{
    public int Id { get; set; }
    public string Description { get; set; } = description;
    public bool IsComplete { get; set; } = isComplete;
}

public enum TaskChoice { Unknown, Add, Remove, MarkAsCompleted, View, Exit }