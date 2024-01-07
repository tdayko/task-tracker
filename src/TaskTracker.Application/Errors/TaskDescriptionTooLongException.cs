using System.Net;

namespace TaskTracker.Application.Errors;

public class TaskDescriptionTooLongException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.MethodNotAllowed;
    public string ErrorMessage => "Task description too long.";
}