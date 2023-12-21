using TaskTracker.Core.Domain;

namespace TaskTracker.Application.Interfaces;

public interface ITaskRepository
{
    Task AddTask(TodoItem todoItem);
    Task RemoveTask(int id);
    Task<IEnumerable<TodoItem>> GetAllTasks();
    Task<TodoItem> GetOneTask(int id);
}