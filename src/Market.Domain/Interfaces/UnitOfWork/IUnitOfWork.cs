using System.Threading.Tasks;

namespace Market.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        Task BeginTransactionAsync();
        Task BeginCommitAsync();
        Task BeginRollbackAsync();
    }
}
