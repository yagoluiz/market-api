using Bogus;
using Market.API.ViewModels.Request.Pagination;

namespace Market.Unit.Tests.Builders
{
    public static class PaginationBuilder
    {
        public static PaginationRequestViewModel PaginationRequest(
            int? page = null,
            int? limit = null
        )
        {
            return new Faker<PaginationRequestViewModel>()
                .CustomInstantiator(faker => new PaginationRequestViewModel
                {
                    Page = page ?? faker.Random.Int(1, 10),
                    Limit = limit ?? faker.Random.Int(10, 100)
                })
                .Generate();
        }
    }
}