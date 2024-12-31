using libraryTask_dexef.Infrastructure.Interface;

namespace libraryTask_dexef.Application
{

    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IBookRepository BookRepository { get; }
        IRefreshTokenRepository RefreshTokenRepository { get; }
        Task SaveChangesAsync(CancellationToken token);
        Task ExecuteTransactionAsync(Action action, CancellationToken token);
        Task ExecuteTransactionAsync(Func<Task> action, CancellationToken token);
    }
}