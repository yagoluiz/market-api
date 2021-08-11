using System;
using System.Diagnostics.CodeAnalysis;
using Market.Infra.Contexts;
using Market.Infra.Seeds;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Market.API.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class EntityContextSeedExtension
    {
        public static void UseDbContextSeedMigration(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();

            var services = scope.ServiceProvider;
            var logger = services.GetRequiredService<ILogger<Startup>>();

            try
            {
                var context = services.GetRequiredService<EntityContext>();

                StreetFairSeed.RunSeed(context);

                logger.LogInformation("Seed street_fair database successfully");
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "An error occurred while seeding the database");
            }
        }
    }
}
