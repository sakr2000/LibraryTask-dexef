

using LibraryTask_dexef.Infrastructure.Interface;
using LibraryTask_dexef.Infrastructure.Data;

namespace LibraryTask_dexef.Application.Repositories
{

    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryDBContext context) : base(context)
        {
        }
    }
}