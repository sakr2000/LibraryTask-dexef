using AutoMapper;
using LibraryTask_dexef.Application;
using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Application.Common.Models;
using LibraryTask_dexef.Application.Common.Exceptions;
using LibraryTask_dexef.Shared.Models.Book;

namespace LibraryTask_dexef.Application.Services
{

    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Pagination<BookDTO>> Get(int pageIndex, int pageSize)
        {
            var books = await _unitOfWork.BookRepository.ToPagination(
                pageIndex: pageIndex,
                pageSize: pageSize,
                orderBy: x => x.Title,
                ascending: true,
                selector: x => new BookDTO
                {
                    Title = x.Title,
                    Author = x.Author,
                    Genre = x.Genre,
                    PublishedYear = x.PublishedYear,
                    IsAvailable = x.IsAvailable
                }
            );

            return books;
        }

        public async Task<BookDTO> Get(int id)
        {
            var book = await _unitOfWork.BookRepository.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> Add(AddBookRequest request, CancellationToken token)
        {
            var book = _mapper.Map<Book>(request);
            await _unitOfWork.ExecuteTransactionAsync(async () => await _unitOfWork.BookRepository.AddAsync(book), token);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> Update(UpdateBookRequest request, CancellationToken token)
        {
            if (await _unitOfWork.BookRepository.AnyAsync(x => x.Id != request.Id))
                throw new FriendlyException("Book not found", "Book not found");

            var book = _mapper.Map<Book>(request);
            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.BookRepository.Update(book), token);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task<BookDTO> Delete(int id, CancellationToken token)
        {

            var existBook = await _unitOfWork.BookRepository.FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new FriendlyException("Book not found", "Book not found");

            await _unitOfWork.ExecuteTransactionAsync(() => _unitOfWork.BookRepository.Delete(existBook), token);
            return _mapper.Map<BookDTO>(existBook);
        }
    }
}