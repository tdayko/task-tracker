using TaskTracker.Domain.Entities;

namespace TaskTracker.Console.TaskClient;

public interface ITaskClient
{
    Task AddTask(TaskItem task);
    Task<IEnumerable<TaskItem>> GetAllTasks();
    Task<TaskItem> GetOneTask(int id);
    Task RemoveTask(int id);
    Task MarkTaskAsDone(int id);
}
