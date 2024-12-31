using AutoMapper;
using LibraryTask_dexef.Application;
using LibraryTask_dexef.Application.Common.Models;
using LibraryTask_dexef.Application.Common.Exceptions;
using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Domain.Entities;
using LibraryTask_dexef.Shared.Models.Book;
using LibraryTask_dexef.Shared.Models.BorrowedBook;

namespace LibraryTask_dexef.Application.Services
{
    public class BorrowedBookService : IBorrowedBooksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BorrowedBookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BorrowedBookDTO> Add(BorrowBookDTO request, CancellationToken token)
        {
            // Check if the user has already borrowed the book (prevent borrowing the same book simultaneously)
            var existingBorrowedBook = await _unitOfWork.BorrowedBooksRepository
                .FirstOrDefaultAsync(x => x.BorrowerId == request.BorrowerId && x.BookId == request.BookId && x.ReturnDate >= DateTime.Now);

            if (existingBorrowedBook != null)
            {
                throw new FriendlyException("This book has already been borrowed by the user", "Borrowing Error");
            }

            // Retrieve the book to check availability
            var book = await _unitOfWork.BookRepository.FirstOrDefaultAsync(x => x.Id == request.BookId)
                        ?? throw new FriendlyException("Book not found", "Book not found");

            // Check if the book is available
            if (!book.IsAvailable)
            {
                throw new FriendlyException("The book is not available for borrowing", "Availability Error");
            }

            // Implement 14 days return policy: Set ReturnDate to 14 days after BorrowDate
            var borrowedBook = _mapper.Map<BorrowedBooks>(request);
            borrowedBook.ReturnDate = borrowedBook.BorrowDate.AddDays(14);  // 14-day return policy

            book.IsAvailable = false;

            // Add the borrowed book record and update the book availability
            await _unitOfWork.ExecuteTransactionAsync(async () =>
            {
                await _unitOfWork.BorrowedBooksRepository.AddAsync(borrowedBook);
                _unitOfWork.BookRepository.Update(book);
            }, token);

            return _mapper.Map<BorrowedBookDTO>(borrowedBook);
        }

        public async Task<BorrowedBookDTO> Delete(int id, CancellationToken token)
        {
            var borrowedBook = await _unitOfWork.BorrowedBooksRepository.FirstOrDefaultAsync(x => x.Id == id)
                                ?? throw new FriendlyException("Borrowed book not found", "Book not found");

            var book = await _unitOfWork.BookRepository.FirstOrDefaultAsync(x => x.Id == borrowedBook.BookId)
                        ?? throw new FriendlyException("Book not found", "Book not found");

            // Mark the book as available upon return
            book.IsAvailable = true;

            // Delete the borrowed book record
            await _unitOfWork.ExecuteTransactionAsync(() =>
            {
                 _unitOfWork.BorrowedBooksRepository.Delete(borrowedBook);
                 _unitOfWork.BookRepository.Update(book);
            }, token);

            return _mapper.Map<BorrowedBookDTO>(borrowedBook);
        }

        public async Task<Pagination<BorrowedBookDTO>> Get(int pageIndex, int pageSize)
        {
            var borrowedBooks = await _unitOfWork.BorrowedBooksRepository
                .ToPagination(
                pageIndex,
                pageSize,
                orderBy: x => x.Id,
                ascending: true,
                selector: x => new BorrowedBookDTO
                {
                    BookId = x.BookId,
                    BorrowerId = x.BorrowerId,
                    BorrowDate = x.BorrowDate,
                    ReturnDate = x.ReturnDate
                });
                return borrowedBooks;
        }

        public async Task<BorrowedBookDTO> Get(int id)
        {
            var borrowedBook = await _unitOfWork.BorrowedBooksRepository.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<BorrowedBookDTO>(borrowedBook);
        }

        public async Task<BorrowedBookDTO> Update(UpdateBorrowedBookDTO request, CancellationToken token)
        {
            var borrowedBook = await _unitOfWork.BorrowedBooksRepository.FirstOrDefaultAsync(x => x.Id == request.Id)
                                ?? throw new FriendlyException("Borrowed book not found", "Record not found");

            // Map the updated request to the borrowed book entity
            _mapper.Map(request, borrowedBook);

            // Execute the transaction to update the borrowed book
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.BorrowedBooksRepository.Update(borrowedBook), token);

            return _mapper.Map<BorrowedBookDTO>(borrowedBook);
        }

        public async Task<BorrowedBookDTO> ReturnBook(ReturnBookDTO request, CancellationToken token)
        {
            // Fetch the borrowed book record
            var borrowedBook = await _unitOfWork.BorrowedBooksRepository.FirstOrDefaultAsync(x => x.Id == request.Id)
                                ?? throw new FriendlyException("Borrowed book record not found", "Record not found");

            // Ensure the book exists
            var book = await _unitOfWork.BookRepository.FirstOrDefaultAsync(x => x.Id == request.BookId)
                        ?? throw new FriendlyException("Book not found", "Book not found");

            // Update the book's availability
            book.IsAvailable = true;

            // Set the ReturnDate to the current time
            borrowedBook.ReturnDate = DateTime.Now;

            // Handle late return logic (optional)
            if (borrowedBook.ReturnDate > borrowedBook.BorrowDate.AddDays(14))
            {
                // Logic for late return (e.g., notify user, log fine)
                Console.WriteLine("Book was returned late");
            }

            // Execute the transaction to update both the borrowed book and the book's availability
            await _unitOfWork.ExecuteTransactionAsync(async () =>
            {
                _unitOfWork.BorrowedBooksRepository.Update(borrowedBook);
                _unitOfWork.BookRepository.Update(book);
            }, token);

            return _mapper.Map<BorrowedBookDTO>(borrowedBook);
        }

    }
}
