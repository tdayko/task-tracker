namespace TaskTracker.Core.Domain;

public class TodoItem(string description, bool isComplete = false)
{
    public int Id { get; set; }
    public string Description { get; set; } = description;
    public bool IsComplete { get; set; } = isComplete;
}

public enum TodoChoice { Unknown, Add, Remove, MarkAsCompleted, View, Exit }