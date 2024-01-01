using Microsoft.EntityFrameworkCore;

using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infra.Database;

namespace TaskTracker.Infra.Repository;

public class TaskRepository(ApplicationDbContext context) : ITaskRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<TaskItem> AddTask(TaskItem taskItem)
    {
        await _context.TaskItems!.AddAsync(taskItem);
        await _context.SaveChangesAsync();
        return taskItem;
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        return await _context.TaskItems!.ToListAsync();
    }

    public async Task<TaskItem> GetOneTask(int id)
    {
        return await _context.TaskItems!.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TaskItem> RemoveTask(int id)
    {
        _context.TaskItems!.Remove(GetOneTask(id).Result);
        await _context.SaveChangesAsync();

        return GetOneTask(id).Result;
    }
}