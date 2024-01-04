using RestSharp;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Console.Services;

public class TaskService(RestClient client)
{
    private readonly RestClient	_client = client;

    public async Task AddTask(TaskItem task)
    {
        var request = new RestRequest("tasks", Method.Post);
        request.AddJsonBody(task);
        await _client.ExecuteAsync(request);
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        var request = new RestRequest("tasks", Method.Get);
        var response = await _client.ExecuteAsync<IEnumerable<TaskItem>>(request);
        return response.Data!;
    }

    public async Task<TaskItem> GetOneTask(int id)
    {
        var request = new RestRequest($"tasks/{id}", Method.Get);
        var response = await _client.ExecuteAsync<TaskItem>(request);
        return response.Data!;
    }

    public async Task RemoveTask(int id)
    {
        var request = new RestRequest($"tasks/{id}", Method.Delete);
        await _client.ExecuteAsync(request);
    }

    public async Task MarkTaskAsDone(int id)
    {
        var request = new RestRequest($"tasks/done/{id}", Method.Put);
        await _client.ExecuteAsync(request);
    }
}
