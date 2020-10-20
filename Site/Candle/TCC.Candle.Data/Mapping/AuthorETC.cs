using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class AuthorETC : BaseEntityConfigurations<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> builder)
        {
            base.Configure(builder);
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).IsRequired(true);

        }
    }
}
