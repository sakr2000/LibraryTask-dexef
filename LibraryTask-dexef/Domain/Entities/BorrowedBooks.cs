using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryTask_dexef.Domain.Entities
{
    public class BorrowedBooks
    {
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        [ForeignKey("Borrower")]
        public Guid BorrowerId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public virtual Book Book { get; set; }
        public virtual ApplicationUser Borrower { get; set; }
    }
}
