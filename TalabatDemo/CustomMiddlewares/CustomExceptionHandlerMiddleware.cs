using DomainLayer.Exceptions;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Shared.ErrorModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TalabatDemo.CustomMiddlewares
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(RequestDelegate Next, ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _next = Next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
                await HandleNotFoundEndPointAsyncC(httpContext);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Somthing Went Wrong");
                await HandleExceptionAsync(httpContext, ex);
            }

            static async Task HandleNotFoundEndPointAsyncC(HttpContext httpContext)
            {
                if (httpContext.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var response = new ErrorToReturn()
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        ErrorMessage = $"End Point {httpContext.Request.Path} is Not Found"
                    };
                    await httpContext.Response.WriteAsJsonAsync(response);
                }
            }

            static async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
            {
                //Set Status Code For Response
                httpContext.Response.StatusCode = ex switch
                {
                    NotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };
                //Set Content Type For Response
                httpContext.Response.ContentType = "application/json";
                // Create Response Object
                var response = new ErrorToReturn()
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = ex.Message
                };
                //Return Object As Json
                //var responseToReturn=JsonSerializer.Serialize(response);
                await httpContext.Response.WriteAsJsonAsync(response);
            }
        } 
    }
}
