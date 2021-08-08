using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Domain.Interfaces.Repositories
{
    public interface IEntityBaseRepository<TEntity>
        : IDisposable where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}