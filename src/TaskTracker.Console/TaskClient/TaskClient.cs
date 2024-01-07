using RestSharp;

using TaskTracker.Domain.Entities;

namespace TaskTracker.Console.TaskClient;

public class TaskClient(RestClient client) : ITaskClient
{
    private readonly RestClient _client = client;

    public async Task AddTask(TaskItem task)
    {
        RestRequest request = new("tasks", Method.Post);
        request.AddJsonBody(task);
        await _client.ExecuteAsync(request);
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        RestRequest request = new("tasks");
        RestResponse<IEnumerable<TaskItem>> response = await _client.ExecuteAsync<IEnumerable<TaskItem>>(request);
        return response.Data!;
    }

    public async Task<TaskItem> GetOneTask(int id)
    {
        RestRequest request = new($"tasks/{id}");
        RestResponse<TaskItem> response = await _client.ExecuteAsync<TaskItem>(request);
        return response.Data!;
    }

    public async Task RemoveTask(int id)
    {
        RestRequest request = new($"tasks/{id}", Method.Delete);
        await _client.ExecuteAsync(request);
    }

    public async Task MarkTaskAsDone(int id)
    {
        RestRequest request = new($"tasks/{id}/done", Method.Put);
        await _client.ExecuteAsync(request);
    }
}