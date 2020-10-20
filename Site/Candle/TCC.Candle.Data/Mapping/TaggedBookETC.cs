using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class TaggedBookETC : BaseEntityConfigurations<TaggedBook>
    {
        public override void Configure(EntityTypeBuilder<TaggedBook> builder)
        {
            base.Configure(builder);
            builder.HasKey(tb => tb.Id);
            builder.HasOne(tb => tb.Tag).WithMany(t => t.Books).HasForeignKey(b => b.TagId);
            builder.HasOne(tb => tb.Book).WithMany(t => t.Tags).HasForeignKey(b => b.BookId);

        }
    }
}
