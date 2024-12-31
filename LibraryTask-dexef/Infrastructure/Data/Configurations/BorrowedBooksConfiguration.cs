using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryTask_dexef.Infrastructure.Data.Configurations
{
    public class BorrowedBooksConfiguration : IEntityTypeConfiguration<BorrowedBooks>
    {
        public void Configure(EntityTypeBuilder<BorrowedBooks> builder)
        {
            
            builder.ToTable("BorrowedBooks");

            
            builder.HasKey(bb => bb.Id);

           
            builder.HasOne(bb => bb.Book)
                   .WithMany()
                   .HasForeignKey(bb => bb.BookId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bb => bb.Borrower)
                   .WithMany()
                   .HasForeignKey(bb => bb.BorrowerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(bb => bb.BorrowDate)
                   .IsRequired();

            builder.Property(bb => bb.ReturnDate)
                   .IsRequired();
        }
    }
}
