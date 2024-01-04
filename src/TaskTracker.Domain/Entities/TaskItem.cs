namespace TaskTracker.Domain.Entities;

public class TaskItem(string description, bool isComplete = false, int? id = null)
{
    public int? Id { get; } = id;
    public string Description { get; private set; } = description;
    public bool IsComplete { get; private set; } = isComplete;

    public void MarkComplete()
    {
        IsComplete = true;
    }
}