using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class VolumeETC : BaseEntityConfigurations<Volume>
    {
        public override void Configure(EntityTypeBuilder<Volume> builder)
        {
            base.Configure(builder);
            builder.HasKey(v => v.Id);
            builder.Property(v => v.Title).IsRequired(true).HasMaxLength(255);
            builder.HasMany(v => v.Books).WithOne(b => b.Volume).HasForeignKey(b => b.VolumeId);
        }
    }
}
