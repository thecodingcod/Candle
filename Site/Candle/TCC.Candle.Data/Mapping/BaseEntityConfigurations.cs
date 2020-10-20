using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.Candle.Data.Entities;

namespace TCC.Candle.Data.Mapping
{
    internal class BaseEntityConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id).ValueGeneratedOnAdd();
            builder.Property(b => b.Created).HasDefaultValueSql("getdate()");
            builder.Property(b => b.Modified).HasDefaultValueSql("getdate()");
        }
    }
}
