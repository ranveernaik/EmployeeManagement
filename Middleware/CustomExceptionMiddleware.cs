using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmployeeManagementCore.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionMiddleware> _logger;
        public CustomExceptionMiddleware(RequestDelegate next, ILogger<CustomExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled Exception Occured");
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = new
            {
                statusCode = StatusCodes.Status500InternalServerError,
                message = ex.Message
            };
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "appllication/json";
            
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}

