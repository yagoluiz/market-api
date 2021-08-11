using System;
using System.Threading.Tasks;
using Market.Domain.Interfaces.UnitOfWork;
using Market.Infra.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace Market.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly EntityContext _entityContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(EntityContext entityContext)
        {
            _entityContext = entityContext;
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            GC.SuppressFinalize(this);
        }

        public async Task<bool> CommitAsync()
        {
            return await _entityContext.SaveChangesAsync() == (int)SaveChanges.Commit;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _entityContext.Database.BeginTransactionAsync();
        }

        public async Task BeginCommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task BeginRollbackAsync()
        {
            await _transaction.RollbackAsync();
        }

        private enum SaveChanges
        {
            Commit = 1
        }
    }
}
