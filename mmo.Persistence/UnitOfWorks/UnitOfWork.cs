using Microsoft.EntityFrameworkCore.Storage;
using mmo.Application.Interfaces.Context;
using mmo.Application.Interfaces.UnitOfWork;
using mmo.Persistence.Context;

namespace mmo.Persistence.UnitOfWorks
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();

        public async Task Rollback() => await _context.Database.RollbackTransactionAsync();

        public async Task Commit() => await _context.Database.CommitTransactionAsync();
    }

}