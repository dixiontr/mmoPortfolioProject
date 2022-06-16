using Microsoft.EntityFrameworkCore.Storage;

namespace mmo.Application.Interfaces.UnitOfWork
{

    public interface IUnitOfWork : IAsyncDisposable
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
        Task Rollback();
        Task Commit();

    }

}