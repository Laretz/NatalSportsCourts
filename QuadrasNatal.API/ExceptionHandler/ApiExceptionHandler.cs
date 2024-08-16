using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace QuadrasNatal.API.ExceptionHandler
{
    public class ApiExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server Error"
            };
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await httpContext.Response.WriteAsJsonAsync(details, cancellationToken);

            return true;
           
        }
    }
}