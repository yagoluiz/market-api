using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Market.Domain.Enums;
using Market.Domain.Interfaces.Notification;
using Market.Domain.Notification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Market.API.Filters
{
    public class DomainNotificationFilter : IAsyncResultFilter
    {
        private readonly IDomainNotification _domainNotification;

        public DomainNotificationFilter(IDomainNotification domainNotification)
        {
            _domainNotification = domainNotification;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (!context.ModelState.IsValid || _domainNotification.HasNotifications)
            {
                var messageNotification = !context.ModelState.IsValid
                    ? context.ModelState.Values
                        .Select(entry => new NotificationMessage(
                            DomainError.ValidationRequest.ToString(),
                            entry.Errors.First().ErrorMessage))
                        .First()
                    : _domainNotification.Notifications
                        .Select(notification => new NotificationMessage(notification.Key, notification.Value))
                        .First();

                var problemDetails = new ProblemDetails
                {
                    Title = "Bad Request",
                    Status = StatusCodes.Status400BadRequest,
                    Instance = context.HttpContext.Request.Path.Value,
                    Detail = JsonSerializer.Serialize(messageNotification)
                };

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/problem+json";

                await using var writer = new Utf8JsonWriter(context.HttpContext.Response.Body);
                JsonSerializer.Serialize(writer, problemDetails);
                await writer.FlushAsync();

                return;
            }

            await next();
        }
    }
}