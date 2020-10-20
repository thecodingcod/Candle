using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class BookETC : BaseEntityConfigurations<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> builder)
        {
            base.Configure(builder);
            builder.HasKey(b => b.Id);
            builder.Property(b => b.VolumeId).IsRequired(false);
            // 1(Book)-to-m(Reviews)
            builder.HasMany(b => b.Reviews).WithOne(r => r.Book).HasForeignKey(b => b.BookId);
        }
    }
}
