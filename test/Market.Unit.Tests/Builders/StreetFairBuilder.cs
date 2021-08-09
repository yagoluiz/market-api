using AutoBogus;
using Market.API.ViewModels.Request.StreetFair;
using Market.API.ViewModels.Response.Pagination;
using Market.API.ViewModels.Response.StreetFair;

namespace Market.Unit.Tests.Builders
{
    public static class StreetFairBuilder
    {
        public static StreetFairFilterRequestViewModel StreetFairFilterRequest =>
            new AutoFaker<StreetFairFilterRequestViewModel>()
                .Generate();

        public static StreetFairCreateRequestViewModel StreetFairCreateRequest =>
            new AutoFaker<StreetFairCreateRequestViewModel>()
                .Generate();

        public static PaginationResponseViewModel<StreetFairResponseViewModel>
            PaginationStreetFairResponse =>
            new AutoFaker<PaginationResponseViewModel<StreetFairResponseViewModel>>()
                .Generate();
    }
}