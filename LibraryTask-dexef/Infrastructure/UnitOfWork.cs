using libraryTask_dexef.Application.Repositories;
using libraryTask_dexef.Application;
using libraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;
using libraryTask_dexef.Application.Common.Exceptions;

namespace libraryTask_dexef.Infrastructure
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDBContext _context;

        public IUserRepository UserRepository { get; }
        public IBookRepository BookRepository { get; }
        public IRefreshTokenRepository RefreshTokenRepository { get; }

        public UnitOfWork(LibraryDBContext dbContext)
        {
            _context = dbContext;
            UserRepository = new UserRepository(_context);
            BookRepository = new BookRepository(_context);
            RefreshTokenRepository = new RefreshTokenRepository(_context);
        }
        public async Task SaveChangesAsync(CancellationToken token)
            => await _context.SaveChangesAsync(token);

        public async Task ExecuteTransactionAsync(Action action, CancellationToken token)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(token);
            try
            {
                action();
                await _context.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(token);
                throw TransactionException.TransactionNotExecuteException(ex);
            }
        }

        public async Task ExecuteTransactionAsync(Func<Task> action, CancellationToken token)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(token);
            try
            {
                await action();
                await _context.SaveChangesAsync(token);
                await transaction.CommitAsync(token);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(token);
                throw TransactionException.TransactionNotExecuteException(ex);
            }
        }
    }
}