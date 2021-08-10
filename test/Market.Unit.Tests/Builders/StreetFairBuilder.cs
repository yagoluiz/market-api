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

        public static StreetFairUpdateRequestViewModel StreetFairUpdateRequest =>
            new AutoFaker<StreetFairUpdateRequestViewModel>()
                .Generate();

        public static StreetFairIdRequestViewModel StreetFairIdRequest =>
            new AutoFaker<StreetFairIdRequestViewModel>()
                .Generate();
        
        public static StreetFairRegisterRequestViewModel StreetFairRegisterRequest =>
            new AutoFaker<StreetFairRegisterRequestViewModel>()
                .Generate();

        public static PaginationResponseViewModel<StreetFairResponseViewModel>
            PaginationStreetFairResponse =>
            new AutoFaker<PaginationResponseViewModel<StreetFairResponseViewModel>>()
                .Generate();
    }
}
