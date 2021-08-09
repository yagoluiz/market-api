using System.Linq;
using System.Threading.Tasks;
using Market.API.Services.Interfaces;
using Market.API.ViewModels.Request.Pagination;
using Market.API.ViewModels.Request.StreetFair;
using Market.API.ViewModels.Response.Pagination;
using Market.API.ViewModels.Response.StreetFair;
using Market.Domain.Entities;
using Market.Domain.Entities.Filters;
using Market.Domain.Enums;
using Market.Domain.Interfaces.Notification;
using Market.Domain.Interfaces.Repositories;
using Market.Domain.Interfaces.UnitOfWork;

namespace Market.API.Services
{
    public class StreetFairService : IStreetFairService
    {
        private readonly IDomainNotification _domainNotification;
        private readonly IStreetFairRepository _streetFairRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StreetFairService(
            IStreetFairRepository streetFairRepository,
            IUnitOfWork unitOfWork,
            IDomainNotification domainNotification
        )
        {
            _streetFairRepository = streetFairRepository;
            _unitOfWork = unitOfWork;
            _domainNotification = domainNotification;
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

        public async Task CreateStreetFairAsync(StreetFairCreateRequestViewModel request)
        {
            var streetFair = await _streetFairRepository.GetByRegister(request.Register);

            if (streetFair != null)
            {
                _domainNotification.AddNotification(DomainError.RegisterAlreadyExists.ToString(),
                    "Register already exists.");
                return;
            }

            await _streetFairRepository.AddAsync(new StreetFair(
                request.Name,
                request.CensusSector,
                request.CensusGrouping,
                request.DistrictCode,
                request.District,
                request.SubCityHallCode,
                request.SubCityHall,
                request.Region5,
                request.Region8,
                request.Register,
                request.Address,
                request.Neighborhood,
                request.Longitude,
                request.Latitude,
                request.AddressNumber,
                request.AddressDetails
            ));
            await _unitOfWork.CommitAsync();
        }
    }
}
