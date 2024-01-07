using System.Net;

namespace TaskTracker.Application.Errors;

public class IdGivenTaskNotFoundException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.NotFound;
    public string ErrorMessage => "Id given not found.";
}