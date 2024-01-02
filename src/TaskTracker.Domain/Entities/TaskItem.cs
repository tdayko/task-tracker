namespace TaskTracker.Domain.Entities;

public class TaskItem(string description, bool isComplete = false)
{
    public int? Id { get; }
    public string Description { get; private set; } = description;
    public bool IsComplete { get; private set; } = isComplete;

    public void MarkComplete()
    {
        IsComplete = true;
    }
}