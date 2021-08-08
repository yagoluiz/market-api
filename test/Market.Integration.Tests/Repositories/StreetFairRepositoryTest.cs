using System.Threading.Tasks;
using Market.Domain.Entities.Filters;
using Market.Infra.Repositories;
using Market.Infra.UnitOfWork;
using Market.Integration.Tests.Builders;
using Market.Integration.Tests.Fixtures;
using Xunit;

namespace Market.Integration.Tests.Repositories
{
    public class StreetFairRepositoryTest : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _databaseFixture;

        public StreetFairRepositoryTest(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
        }

        [Fact(DisplayName = "Insert and get all street fairs by pagination records in database when not exist filters")]
        public async Task GetAllStreetFairsByPaginationRecordsInDatabaseWhenNotExistFiltersTest()
        {
            var context = _databaseFixture.CreateContext;

            var unitOfWork = new UnitOfWork(context);
            var repository = new StreetFairRepository(context);

            await repository.AddRangeAsync(StreetFairBuilder.CreateStreetFairs);
            await unitOfWork.CommitAsync();

            var financialExchanges = await repository.GetAllByPaginationAsync(
                1,
                10,
                new StreetFairFilter(null, null, null, null)
            );

            Assert.NotEmpty(financialExchanges);
        }
    }
}
