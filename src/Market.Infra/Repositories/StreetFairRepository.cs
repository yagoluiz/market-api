using System.Linq;
using System.Threading.Tasks;
using Market.Domain.Entities;
using Market.Domain.Entities.Filters;
using Market.Domain.Interfaces.Repositories;
using Market.Infra.Contexts;
using Market.Infra.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Market.Infra.Repositories
{
    public class StreetFairRepository
        : EntityBaseRepository<StreetFair>, IStreetFairRepository
    {
        public StreetFairRepository(EntityContext context)
            : base(context)
        {
        }

        public async Task<Pagination<StreetFair>> GetAllByPaginationAsync(int page, int limit, StreetFairFilter filter)
        {
            var streetFairs = DbSet.AsNoTracking();

            if (!string.IsNullOrEmpty(filter.Name))
                streetFairs = streetFairs.Where(streetFair =>
                    streetFair.Name.ToUpper().Contains(filter.Name.ToUpper()));

            if (!string.IsNullOrEmpty(filter.District))
                streetFairs = streetFairs.Where(streetFair =>
                    streetFair.District.ToUpper().Contains(filter.District.ToUpper()));

            if (!string.IsNullOrEmpty(filter.Region5))
                streetFairs = streetFairs.Where(streetFair =>
                    streetFair.Region5.ToUpper().Contains(filter.Region5.ToUpper()));

            if (!string.IsNullOrEmpty(filter.Neighborhood))
                streetFairs = streetFairs.Where(streetFair =>
                    streetFair.Neighborhood.ToUpper().Contains(filter.Neighborhood.ToUpper()));

            return await streetFairs
                .OrderByDescending(streetFair => streetFair.CreatedDate)
                .PaginateAsync(page, limit);
        }
    }
}