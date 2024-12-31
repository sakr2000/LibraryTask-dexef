using LibraryTask_dexef.Application.Common.Models;
using LibraryTask_dexef.Shared.Models.BorrowedBook;

namespace LibraryTask_dexef.Application.Common.Interfaces
{
    public interface IBorrowedBooksService
    {
        Task<Pagination<BorrowedBookDTO>> Get(int pageIndex, int pageSize);
        Task<BorrowedBookDTO> Get(int id);
        Task<BorrowedBookDTO> Add(BorrowBookDTO request, CancellationToken token);
        Task<BorrowedBookDTO> Update(UpdateBorrowedBookDTO request, CancellationToken token);
        Task<BorrowedBookDTO> Delete(int id, CancellationToken token);
        Task<BorrowedBookDTO> ReturnBook(ReturnBookDTO request, CancellationToken token);
    }
}
