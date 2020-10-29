using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class ShelfETC : BaseEntityConfigurations<Shelf>
    {
        public override void Configure(EntityTypeBuilder<Shelf> builder)
        {
            base.Configure(builder);
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Title).IsRequired().HasMaxLength(255);
            builder.HasMany(s => s.Books).WithOne(b => b.Shelf).HasPrincipalKey(s => s.Id).HasForeignKey(x => x.ShelfId);
        }
    }
}
