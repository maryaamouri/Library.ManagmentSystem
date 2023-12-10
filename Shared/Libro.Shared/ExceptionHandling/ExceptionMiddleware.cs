using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Libro.Shared.ExceptionHandling
{
    internal class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }catch (ApplicationException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                var json = JsonSerializer.Serialize(ex.Message);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
