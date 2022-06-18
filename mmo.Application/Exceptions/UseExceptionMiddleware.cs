using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using mmo.Application.Exceptions.CustomExceptions;

namespace mmo.Application.Exceptions
{
    public class UseExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                var culture = response.Headers.ContentLanguage.ToString();
                response.ContentType = "application/json";
                response.StatusCode = StatusCodes.Status500InternalServerError;
                var result = JsonSerializer.Serialize(ExceptionHandler.HandleException(new UnhandledException(),culture));
                await response.WriteAsync(result);
            }
        }

    }

}