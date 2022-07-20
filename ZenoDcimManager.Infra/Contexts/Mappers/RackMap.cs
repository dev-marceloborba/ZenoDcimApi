using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RackMap : IEntityTypeConfiguration<Rack>
    {
        public void Configure(EntityTypeBuilder<Rack> builder)
        {
            builder.ToTable("Rack");
            builder.Property(x => x.Localization).HasColumnType("varchar(12)");
        }
    }
}