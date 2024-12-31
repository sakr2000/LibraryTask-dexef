using LibraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;

namespace LibraryTask_dexef.Application.Repositories
{
    public class BorrowedBooksRepository : GenericRepository<BorrowedBooks>, IBorrowedBooksRepository
    {
        public BorrowedBooksRepository(LibraryDBContext context) : base(context)
        {
        }
    }
}
