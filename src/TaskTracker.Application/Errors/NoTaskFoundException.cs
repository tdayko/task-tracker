using System.Net;

namespace TaskTracker.Application.Errors;

public class NoTaskFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "No tasks found.";
}