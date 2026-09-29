using EProcurementRefactor.Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace EProcurementRefactor.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        public class GlobalException
        {
            private readonly RequestDelegate _next;
            public GlobalException(RequestDelegate next)
            {
                _next = next;
            }
            public async Task InvokeAsync(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex);
                }
            }
            private async Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                var response = context.Response.ContentType = "application/json";
                context.Response.StatusCode = exception switch
                {
                    UnAuthenticatedException => 401,
                    _ => 500
                };

                await context.Response.WriteAsJsonAsync(new ProblemDetails
                {
                    Status = context.Response.StatusCode,
                    Detail = exception.Message
                });
            }
        }
    }
}
