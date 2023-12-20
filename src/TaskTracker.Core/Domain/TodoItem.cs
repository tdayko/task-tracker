namespace TaskTracker.Core.Domain;

public class TodoItem(string description, bool isComplete = false)
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = description;
    public bool IsComplete { get; set; } = isComplete;
}

public enum TodoChoice { Unknown, Add, Remove, MarkAsCompleted, View, Exit }