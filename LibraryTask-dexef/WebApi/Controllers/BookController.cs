using LibraryTask_dexef.Application.Common.Interfaces;
using LibraryTask_dexef.Shared.Models.Book;
using LibraryTask_dexef.Shared.Models.BorrowedBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryTask_dexef.WebApi.Controllers
{

    public class BookController : BaseController
    {
        private readonly IBookService _bookService;
        private readonly IBorrowedBooksService _borrowedBooksService;

        public BookController(IBookService bookService, IBorrowedBooksService borrowedBooksService)
        {
            _bookService = bookService;
            _borrowedBooksService = borrowedBooksService;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
            => Ok(await _bookService.Get(id));

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(int pageIndex = 0, int pageSize = 10)
            => Ok(await _bookService.Get(pageIndex, pageSize));

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddBookRequest request, CancellationToken token)
            => Ok(await _bookService.Add(request, token));

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(UpdateBookRequest request, CancellationToken token)
            => Ok(await _bookService.Update(request, token));

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id, CancellationToken token)
            => Ok(await _bookService.Delete(id, token));

        [HttpGet("borrowed-books/{id}")] 
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetBorrowedBooks(int id)
            => Ok(await _borrowedBooksService.Get(id));

        [HttpGet("borrowed-books")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetBorrowedBooks(int pageIndex = 0, int pageSize = 10)
            => Ok(await _borrowedBooksService.Get(pageIndex, pageSize));

        [HttpPost("borrow-book")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> BorrowBook(BorrowBookDTO request, CancellationToken token)
            => Ok(await _borrowedBooksService.Add(request, token));

        [HttpDelete("return-book/{id}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> ReturnBook(int id, CancellationToken token)
            => Ok(await _borrowedBooksService.Delete(id, token));

        [HttpPut("return-book")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> ReturnBook(ReturnBookDTO request, CancellationToken token)
            => Ok(await _borrowedBooksService.ReturnBook(request, token));
    }
}