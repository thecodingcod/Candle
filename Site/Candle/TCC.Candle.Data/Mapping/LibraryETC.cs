using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class LibraryETC : BaseEntityConfigurations<Library>
    {
        public override void Configure(EntityTypeBuilder<Library> builder)
        {
            base.Configure(builder);
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Title).IsRequired().HasMaxLength(255);

            builder.HasMany(l => l.Shelves).WithOne(s => s.Library).HasForeignKey(s => s.LibraryId);
        }
    }
}
