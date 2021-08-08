using System;
using Market.Infra.Contexts;
using Market.Integration.Tests.Setups;
using Microsoft.EntityFrameworkCore;

namespace Market.Integration.Tests.Fixtures
{
    public class DatabaseFixture : IDisposable
    {
        private readonly DatabaseSetup _databaseSetup;
        private readonly EntityContext _entityContext;

        public DatabaseFixture()
        {
            _databaseSetup = new DatabaseSetup();

            _entityContext = new EntityContext(_databaseSetup.Options);
            _entityContext.Database.Migrate();
        }

        public EntityContext CreateContext => new(_databaseSetup.Options);

        public void Dispose()
        {
            _entityContext.Database.EnsureDeleted();
        }
    }
}