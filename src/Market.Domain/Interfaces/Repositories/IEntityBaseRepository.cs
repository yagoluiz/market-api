using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.Domain.Interfaces.Repositories
{
    public interface IEntityBaseRepository<in TEntity>
        : IDisposable where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
