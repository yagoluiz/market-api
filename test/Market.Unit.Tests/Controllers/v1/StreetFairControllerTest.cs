using System.Threading.Tasks;
using Market.API.Controllers.v1;
using Market.API.Services.Interfaces;
using Market.Unit.Tests.Builders;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Market.Unit.Tests.Controllers.v1
{
    public class StreetFairControllerTest
    {
        private readonly Mock<IStreetFairService> _streetFairServiceMock;

        public StreetFairControllerTest()
        {
            _streetFairServiceMock = new Mock<IStreetFairService>();
        }

        [Fact(DisplayName = "Get all street fairs by pagination when is success")]
        public async Task GetAllStreetFairsByPaginationWhenIsSuccessTest()
        {
            var paginationRequest = PaginationBuilder.PaginationRequest();
            var filterRequest = StreetFairBuilder.StreetFairFilterRequest;

            _streetFairServiceMock.Setup(setup =>
                    setup.GetAllStreetFairsByPaginationAsync(paginationRequest, filterRequest))
                .ReturnsAsync(StreetFairBuilder.PaginationStreetFairResponse);

            var controller = new StreetFairController(_streetFairServiceMock.Object);
            var result = await controller.GetAllStreetFairsByPaginationAsync(paginationRequest, filterRequest);

            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact(DisplayName = "Create street fair when is success")]
        public async Task CreateStreetFairWhenIsSuccessTest()
        {
            var request = StreetFairBuilder.StreetFairCreateRequest;

            var controller = new StreetFairController(_streetFairServiceMock.Object);
            var result = await controller.CreateStreetFairAsync(request);

            Assert.IsType<CreatedResult>(result);
        }

        [Fact(DisplayName = "Update street fair when is success")]
        public async Task UpdateStreetFairWhenIsSuccessTest()
        {
            var requestId = StreetFairBuilder.StreetFairIdRequest;
            var request = StreetFairBuilder.StreetFairUpdateRequest;

            _streetFairServiceMock.Setup(setup =>
                    setup.UpdateStreetFairAsync(requestId, request))
                .ReturnsAsync(true);

            var controller = new StreetFairController(_streetFairServiceMock.Object);
            var result = await controller.UpdateStreetFairAsync(requestId, request);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact(DisplayName = "Update street fair when not is success")]
        public async Task UpdateStreetFairWhenIsNotSuccessTest()
        {
            var requestId = StreetFairBuilder.StreetFairIdRequest;
            var request = StreetFairBuilder.StreetFairUpdateRequest;

            var controller = new StreetFairController(_streetFairServiceMock.Object);
            var result = await controller.UpdateStreetFairAsync(requestId, request);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact(DisplayName = "Remove street fair when is success")]
        public async Task RemoveStreetFairWhenIsSuccessTest()
        {
            var request = StreetFairBuilder.StreetFairRegisterRequest;

            _streetFairServiceMock.Setup(setup =>
                    setup.RemoveStreetFairAsync(request))
                .ReturnsAsync(true);

            var controller = new StreetFairController(_streetFairServiceMock.Object);
            var result = await controller.RemoveStreetFairAsync(request);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact(DisplayName = "Remove street fair when not is success")]
        public async Task RemoveStreetFairWhenIsNotSuccessTest()
        {
            var request = StreetFairBuilder.StreetFairRegisterRequest;

            var controller = new StreetFairController(_streetFairServiceMock.Object);
            var result = await controller.RemoveStreetFairAsync(request);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
