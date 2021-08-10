using System.Threading.Tasks;
using Market.Domain.Entities;
using Market.Domain.Entities.Filters;

namespace Market.Domain.Interfaces.Repositories
{
    public interface IStreetFairRepository
        : IEntityBaseRepository<StreetFair>
    {
        Task<Pagination<StreetFair>> GetAllByPaginationAsync(int page, int limit, StreetFairFilter filter);
        Task<StreetFair> GetByIdAsync(int id);
        Task<StreetFair> GetByRegisterAsync(string register);
    }
}
