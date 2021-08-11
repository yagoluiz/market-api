using System.Diagnostics.CodeAnalysis;
using Market.API.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Market.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class LogExtensions
    {
        public static void UseLogMiddleware(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<LogMiddleware>();
        }
    }
}
