using TaskTracker.Core.Domain;
namespace TaskTracker.Application.Interface;

public interface ITaskRepository
{
    Task AddTask(TodoItem todoItem);
    Task RemoveTask(int id);
    Task<IEnumerable<TodoItem>> ViewTasks();
    void MarkTaskAsCompleted(int id);
    void Exit();
}