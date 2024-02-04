﻿using TaskTracker.Api.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.Errors;

namespace TaskTracker.Api.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    [NonAction]
    public IActionResult Error()
    {
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
        var (statusCode, message) = exception switch
        {
            IServiceException serviceException => ((int)serviceException.StatusCode, serviceException.ErrorMessage),
            _ => (StatusCodes.Status500InternalServerError, "An error occurred while processing your request")
        };

        return Problem(title: message, statusCode: statusCode);
    }
}