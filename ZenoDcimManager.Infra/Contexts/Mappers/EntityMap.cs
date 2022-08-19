using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Infra.Contexts.Conversions;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class EntityMap : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            // builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedDate).HasConversion(typeof(UtcValueConverter));
        }
    }
}