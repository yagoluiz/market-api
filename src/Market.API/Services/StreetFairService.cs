using System.Linq;
using System.Threading.Tasks;
using Market.API.Services.Interfaces;
using Market.API.ViewModels.Request.Pagination;
using Market.API.ViewModels.Request.StreetFair;
using Market.API.ViewModels.Response.Pagination;
using Market.API.ViewModels.Response.StreetFair;
using Market.Domain.Entities.Filters;
using Market.Domain.Interfaces.Repositories;
using Market.Domain.Interfaces.UnitOfWork;

namespace Market.API.Services
{
    public class StreetFairService : IStreetFairService
    {
        private readonly IStreetFairRepository _streetFairRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StreetFairService(
            IStreetFairRepository streetFairRepository,
            IUnitOfWork unitOfWork
        )
        {
            _streetFairRepository = streetFairRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponseViewModel<StreetFairResponseViewModel>> GetAllStreetFairsByPaginationAsync(
            PaginationRequestViewModel request,
            StreetFairFilterRequestViewModel filter
        )
        {
            var streetFairs = await _streetFairRepository.GetAllByPaginationAsync(
                request.Page,
                request.Limit,
                new StreetFairFilter(
                    filter.Name,
                    filter.District,
                    filter.Region5,
                    filter.Neighborhood
                ));

            return new PaginationResponseViewModel<StreetFairResponseViewModel>(
                streetFairs.Page,
                streetFairs.TotalPages,
                streetFairs.TotalItems,
                streetFairs.Select(streetFair => new StreetFairResponseViewModel(
                    streetFair.Id,
                    streetFair.Name,
                    streetFair.CensusSector,
                    streetFair.CensusGrouping,
                    streetFair.DistrictCode,
                    streetFair.District,
                    streetFair.SubCityHallCode,
                    streetFair.SubCityHall,
                    streetFair.Region5,
                    streetFair.Region8,
                    streetFair.Register,
                    streetFair.Address,
                    streetFair.AddressNumber,
                    streetFair.Neighborhood,
                    streetFair.AddressDetails,
                    streetFair.Longitude,
                    streetFair.Latitude,
                    streetFair.CreatedDate
                ))
            );
        }
    }
}