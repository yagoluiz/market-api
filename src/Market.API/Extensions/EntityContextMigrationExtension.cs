using System;
using Market.Infra.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Market.API.Extensions
{
    public static class EntityContextMigrationExtension
    {
        public static void UseDbContextMigration(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();

            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Startup>>();

            try
            {
                var context = services.GetRequiredService<EntityContext>();

                context.Database.Migrate();

                logger.LogInformation("Migration database successfully");
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An error occurred while migrating the database");
            }
        }
    }
}