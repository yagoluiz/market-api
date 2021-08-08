using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace Market.API.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ErrorHandlerMiddleware(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task Invoke(HttpContext context)
        {
            var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

            if (exception == null) return;

            var problemDetails = new ProblemDetails
            {
                Title = "Internal Server Error",
                Status = StatusCodes.Status500InternalServerError,
                Instance = context.Request.Path.Value,
                Detail = exception.InnerException == null
                    ? $"{exception.Message}"
                    : $"{exception.Message} | {exception.InnerException}"
            };

            if (_webHostEnvironment.IsDevelopment()) problemDetails.Detail += $": {exception.StackTrace}";

            context.Response.StatusCode = problemDetails.Status.Value;
            context.Response.ContentType = "application/problem+json";

            await using var writer = new Utf8JsonWriter(context.Response.Body);
            JsonSerializer.Serialize(writer, problemDetails);
            await writer.FlushAsync();
        }
    }
}
