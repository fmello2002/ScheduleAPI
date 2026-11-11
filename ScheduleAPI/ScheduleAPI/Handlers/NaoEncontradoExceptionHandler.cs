using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.Application.Exceptions;

namespace ScheduleAPI.Handlers
{
    public class NaoEncontradoExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if (exception is not NaoEncontradoException)
                return false;

            httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
            {
                HttpContext = httpContext,
                Exception = exception,
                ProblemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "Regra de negócio violada",
                    Detail = exception.Message
                }
            });
        }
    }
}