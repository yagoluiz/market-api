using System.Threading.Tasks;
using Market.API.ViewModels.Request.Pagination;
using Market.API.ViewModels.Request.StreetFair;
using Market.API.ViewModels.Response.Pagination;
using Market.API.ViewModels.Response.StreetFair;

namespace Market.API.Services.Interfaces
{
    public interface IStreetFairService
    {
        Task<PaginationResponseViewModel<StreetFairResponseViewModel>> GetAllStreetFairsByPaginationAsync(
            PaginationRequestViewModel request,
            StreetFairFilterRequestViewModel filter
        );

        Task CreateStreetFairAsync(StreetFairCreateRequestViewModel request);

        Task<bool> UpdateStreetFairAsync(
            StreetFairIdRequestViewModel requestId,
            StreetFairUpdateRequestViewModel request
        );

        Task<bool> RemoveStreetFairAsync(
            StreetFairRegisterRequestViewModel request
        );
    }
}
