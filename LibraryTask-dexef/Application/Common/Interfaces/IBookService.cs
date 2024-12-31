
using libraryTask_dexef.Application.Common.Models;
using LibraryTask_dexef.Shared.Models.Book;

namespace libraryTask_dexef.Application.Common.Interfaces
{

    public interface IBookService
    {
        Task<Pagination<BookDTO>> Get(int pageIndex, int pageSize);
        Task<BookDTO> Get(int id);
        Task<BookDTO> Add(AddBookRequest request, CancellationToken token);
        Task<BookDTO> Update(UpdateBookRequest request, CancellationToken token);
        Task<BookDTO> Delete(int id, CancellationToken token);
    }
}