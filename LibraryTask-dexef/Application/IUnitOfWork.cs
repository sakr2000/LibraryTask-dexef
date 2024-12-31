using LibraryTask_dexef.Infrastructure.Interface;

namespace LibraryTask_dexef.Application
{

    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBookRepository BookRepository { get; }

        IBorrowedBooksRepository BorrowedBooksRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        Task SaveChangesAsync(CancellationToken token);
        Task ExecuteTransactionAsync(Action action, CancellationToken token);
        Task ExecuteTransactionAsync(Func<Task> action, CancellationToken token);
    }
}