using System.Net;

namespace TaskTracker.Application.Errors;

public interface IServiceException
{
    HttpStatusCode StatusCode { get; }
    string ErrorMessage { get; }
}