using System.Linq;
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

        [Fact(DisplayName = "Insert and get all street fairs by pagination records in database when filter not exist")]
        public async Task GetAllStreetFairsByPaginationRecordsInDatabaseWhenFiltersNotExistTest()
        {
            var context = _databaseFixture.CreateContext;

            var unitOfWork = new UnitOfWork(context);
            var repository = new StreetFairRepository(context);

            await repository.AddRangeAsync(StreetFairBuilder.CreateStreetFairs);
            await unitOfWork.CommitAsync();

            var streetFairs = await repository.GetAllByPaginationAsync(
                1,
                10,
                new StreetFairFilter(null, null, null, null)
            );

            Assert.NotEmpty(streetFairs);
        }

        [Fact(DisplayName = "Insert and get all street fairs by pagination records in database when filter exist")]
        public async Task GetAllStreetFairsByPaginationRecordsInDatabaseWhenNotFilterExistTest()
        {
            var context = _databaseFixture.CreateContext;

            var unitOfWork = new UnitOfWork(context);
            var repository = new StreetFairRepository(context);

            var builder = StreetFairBuilder.CreateStreetFairs.ToList();

            await repository.AddRangeAsync(builder);
            await unitOfWork.CommitAsync();

            var nameFilter = builder.First().Name;

            var streetFairs = await repository.GetAllByPaginationAsync(
                1,
                10,
                new StreetFairFilter(nameFilter, null, null, null)
            );

            Assert.Contains(streetFairs, streetFair => streetFair.Name == nameFilter);
        }

        [Fact(DisplayName =
            "Insert and get all street fairs by pagination records in database when more than one filter exist")]
        public async Task GetAllStreetFairsByPaginationRecordsInDatabaseWhenMoreThanOneFilterExistTest()
        {
            var context = _databaseFixture.CreateContext;

            var unitOfWork = new UnitOfWork(context);
            var repository = new StreetFairRepository(context);

            var builder = StreetFairBuilder.CreateStreetFairs.ToList();

            await repository.AddRangeAsync(builder);
            await unitOfWork.CommitAsync();

            var nameFilter = builder.First().Name;
            var region5Filter = builder.First().Region5;

            var streetFairs = await repository.GetAllByPaginationAsync(
                1,
                10,
                new StreetFairFilter(nameFilter, null, region5Filter, null)
            );

            Assert.Contains(streetFairs, streetFair => streetFair.Name == nameFilter);
            Assert.Contains(streetFairs, streetFair => streetFair.Region5 == region5Filter);
        }
    }
}