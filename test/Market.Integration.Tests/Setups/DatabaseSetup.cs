using System;
using Market.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Market.Integration.Tests.Setups
{
    public class DatabaseSetup
    {
        private readonly DbContextOptionsBuilder<EntityContext> _optionsBuilder;

        public DatabaseSetup()
        {
            _optionsBuilder = InitContext(InitServiceProvider());
        }

        public DbContextOptions<EntityContext> Options => _optionsBuilder.Options;

        private static DbContextOptionsBuilder<EntityContext> InitContext(IServiceProvider serviceProvider)
        {
            return new DbContextOptionsBuilder<EntityContext>()
                .UseNpgsql(
                    $"Server=localhost;Port=5432;Database=market_{Guid.NewGuid()};User ID=postgres;Password=postgres;Integrated Security=true;Pooling=true")
                .UseInternalServiceProvider(serviceProvider);
        }

        private static ServiceProvider InitServiceProvider()
        {
            return new ServiceCollection()
                .AddEntityFrameworkNpgsql()
                .BuildServiceProvider();
        }
    }
}