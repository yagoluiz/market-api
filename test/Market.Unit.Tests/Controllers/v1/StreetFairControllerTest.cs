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

        [Fact(DisplayName = "Create street fairs when is success")]
        public async Task CreateStreetFairWhenIsSuccessTest()
        {
            var request = StreetFairBuilder.StreetFairCreateRequest;

            var controller = new StreetFairController(_streetFairServiceMock.Object);
            var result = await controller.CreateStreetFairAsync(request);

            Assert.IsType<CreatedResult>(result);
        }
    }
}