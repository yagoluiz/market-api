using System.Collections.Generic;
using System.Threading.Tasks;
using Market.API.Services;
using Market.Domain.Entities.Filters;
using Market.Domain.Enums;
using Market.Domain.Interfaces.Notification;
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
        private readonly Mock<IDomainNotification> _domainNotificationMock;
        private readonly Mock<IStreetFairRepository> _streetFairRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public StreetFairServiceTest()
        {
            _streetFairRepositoryMock = new Mock<IStreetFairRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _domainNotificationMock = new Mock<IDomainNotification>();
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

        [Fact(DisplayName = "Create street fair when register not exist")]
        public async Task CreateStreetFairWhenRegisterNotExistTest()
        {
            var request = StreetFairBuilder.StreetFairCreateRequest;

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            await service.CreateStreetFairAsync(request);

            _unitOfWorkMock.Verify(unitOfWork => unitOfWork.CommitAsync());
        }

        [Fact(DisplayName = "Create street fair when register exist")]
        public async Task CreateStreetFairWhenRegisterExistTest()
        {
            var request = StreetFairBuilder.StreetFairCreateRequest;

            _streetFairRepositoryMock.Setup(setup => setup.GetByRegisterAsync(request.Register))
                .ReturnsAsync(StreetFairEntityBuilder.StreetFair);

            _domainNotificationMock.Setup(setup => setup.Notifications)
                .Returns(new List<NotificationMessage>
                {
                    new(DomainError.RegisterAlreadyExists.ToString(),
                        "Register already exists.")
                });

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            await service.CreateStreetFairAsync(request);

            _domainNotificationMock.Verify(domainNotification => domainNotification.AddNotification(
                DomainError.RegisterAlreadyExists.ToString(),
                "Register already exists."), Times.Once);
        }

        [Fact(DisplayName = "Update street fair when record exist")]
        public async Task UpdateStreetFairWhenRecordExistTest()
        {
            var requestId = StreetFairBuilder.StreetFairIdRequest;
            var request = StreetFairBuilder.StreetFairUpdateRequest;

            _streetFairRepositoryMock.Setup(setup => setup.GetByIdAsync(requestId.Id))
                .ReturnsAsync(StreetFairEntityBuilder.StreetFair);

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            var result = await service.UpdateStreetFairAsync(requestId, request);

            Assert.True(result);
        }

        [Fact(DisplayName = "Update street fair when record not exist")]
        public async Task UpdateStreetFairWhenRecordNotExistTest()
        {
            var requestId = StreetFairBuilder.StreetFairIdRequest;
            var request = StreetFairBuilder.StreetFairUpdateRequest;

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            var result = await service.UpdateStreetFairAsync(requestId, request);

            Assert.False(result);
        }

        [Fact(DisplayName = "Remove street fair when record exist")]
        public async Task RemoveStreetFairWhenRecordExistTest()
        {
            var request = StreetFairBuilder.StreetFairRegisterRequest;

            _streetFairRepositoryMock.Setup(setup => setup.GetByRegisterAsync(request.Register))
                .ReturnsAsync(StreetFairEntityBuilder.StreetFair);

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            var result = await service.RemoveStreetFairAsync(request);

            Assert.True(result);
        }

        [Fact(DisplayName = "Remove street fair when record not exist")]
        public async Task RemoveStreetFairWhenRecordNotExistTest()
        {
            var request = StreetFairBuilder.StreetFairRegisterRequest;

            var service = new StreetFairService(
                _streetFairRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _domainNotificationMock.Object
            );
            var result = await service.RemoveStreetFairAsync(request);

            Assert.False(result);
        }
    }
}
