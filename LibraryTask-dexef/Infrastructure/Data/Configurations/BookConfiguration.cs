using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace libraryTask_dexef.Infrastructure.Data.Configurations
{

    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");

            //Id
            builder.HasKey(x => x.Id);
        }
    }
}