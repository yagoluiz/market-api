using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Market.Domain.Interfaces.Repositories;
using Market.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Market.Infra.Repositories
{
    public class EntityBaseRepository<TEntity>
        : IEntityBaseRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> DbSet;

        public EntityBaseRepository(EntityContext context)
        {
            DbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entity)
        {
            await DbSet.AddRangeAsync(entity);
        }

        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}