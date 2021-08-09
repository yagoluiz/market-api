using System.Threading.Tasks;
using Market.API.Services;
using Market.Domain.Entities.Filters;
using Market.Domain.Interfaces.Repositories;
using Market.Domain.Interfaces.UnitOfWork;
using Market.Domain.Notification;
using Market.Unit.Tests.Builders;
using Moq;
using Xunit;

namespace Market.Unit.Tests.Services
{
    public class StreetFairServiceTest
    {
        private readonly Mock<DomainNotification> _domainNotificationMock;
        private readonly Mock<IStreetFairRepository> _streetFairRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public StreetFairServiceTest()
        {
            _streetFairRepositoryMock = new Mock<IStreetFairRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _domainNotificationMock = new Mock<DomainNotification>();
        }

        [Fact(DisplayName = "Get all street fairs by pagination when items is not empty")]
        public async Task GetAllStreetFairsByPaginationWhenItemsIsNotEmptyTest()
        {
            var paginationRequest = PaginationBuilder.PaginationRequest();
            var filterRequest = StreetFairBuilder.StreetFairFilterRequest;

            _streetFairRepositoryMock.Setup(setup => setup.GetAllByPaginationAsync(
                    paginationRequest.Page,
                    paginationRequest.Limit,
                    new StreetFairFilter(
                        filterRequest.Name,
                        filterRequest.District,
                        filterRequest.Region5,
                        filterRequest.Neighborhood)
                ))
                .ReturnsAsync(StreetFairEntityBuilder.PaginationStreetFairs());

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            var result =
                await service.GetAllStreetFairsByPaginationAsync(paginationRequest, filterRequest);

            Assert.NotEmpty(result.Items);
        }

        [Fact(DisplayName = "Get all street fairs by pagination when items is empty")]
        public async Task GetAllStreetFairsByPaginationWhenItemsIsEmptyTest()
        {
            var paginationRequest = PaginationBuilder.PaginationRequest();
            var filterRequest = StreetFairBuilder.StreetFairFilterRequest;

            _streetFairRepositoryMock.Setup(setup => setup.GetAllByPaginationAsync(
                    paginationRequest.Page,
                    paginationRequest.Limit,
                    new StreetFairFilter(
                        filterRequest.Name,
                        filterRequest.District,
                        filterRequest.Region5,
                        filterRequest.Neighborhood)
                ))
                .ReturnsAsync(StreetFairEntityBuilder.PaginationStreetFairs(false));

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            var result =
                await service.GetAllStreetFairsByPaginationAsync(paginationRequest, filterRequest);

            Assert.Empty(result.Items);
        }
    }
}