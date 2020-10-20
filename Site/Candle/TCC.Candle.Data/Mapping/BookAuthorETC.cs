using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class BookAuthorETC : BaseEntityConfigurations<BookAuthor>
    {
        public override void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            base.Configure(builder);
            builder.HasKey(ba => ba.Id);
            builder.HasOne(b => b.Book).WithMany(ba => ba.Authors).HasForeignKey(ba => ba.BookId);
            builder.HasOne(b => b.Author).WithMany(ba => ba.Books).HasForeignKey(ba => ba.AuthorId);
        }
    }
}
