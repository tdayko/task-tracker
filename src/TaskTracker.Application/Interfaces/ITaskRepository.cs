using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Interfaces;

public interface ITaskRepository
{
    Task AddTask(TaskItem taskItem);
    Task RemoveTask(int id);
    Task<IEnumerable<TaskItem>> GetAllTasks();
    Task<TaskItem> GetOneTask(int id);
}