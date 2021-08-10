using Market.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Market.API.Extensions
{
    public static class LogExtensions
    {
        public static void UseLogMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LogMiddleware>();
        }
    }
}
