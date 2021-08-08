using System.Linq;
using System.Threading.Tasks;
using Market.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Market.Infra.Extensions
{
    public static class EntityPaginationExtension
    {
        public static async Task<Pagination<TEntity>> PaginateAsync<TEntity>(
            this IQueryable<TEntity> source,
            int page,
            int limit
        ) where TEntity : class
        {
            var count = await source.CountAsync();
            var items = await source.Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return new Pagination<TEntity>(items, count, page, limit);
        }
    }
}