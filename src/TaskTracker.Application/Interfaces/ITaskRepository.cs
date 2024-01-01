using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem> AddTask(TaskItem taskItem);
    Task<TaskItem> RemoveTask(int id);
    Task<IEnumerable<TaskItem>> GetAllTasks();
    Task<TaskItem> GetOneTask(int id);
}