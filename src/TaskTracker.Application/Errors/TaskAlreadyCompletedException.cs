using System.Net;

namespace TaskTracker.Application.Errors;

public class TaskAlreadyCompletedException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "The task is already marked as complete.";
}