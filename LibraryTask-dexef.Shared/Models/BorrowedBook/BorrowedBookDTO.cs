using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryTask_dexef.Shared.Models.BorrowedBook
{
    public class BorrowedBookDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Guid BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class BorrowBookDTO
    {
        public int BookId { get; set; }
        public Guid BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class UpdateBorrowedBookDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Guid BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }

    public class ReturnBookDTO
    {

        public int Id { get; set; }
        public int BookId { get; set; }
        public Guid BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}
