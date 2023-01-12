using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RackMap : IEntityTypeConfiguration<Rack>
    {
        public void Configure(EntityTypeBuilder<Rack> builder)
        {
            builder.ToTable("Rack");
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
            builder.Property(x => x.Localization).HasColumnType("varchar(12)");
            builder.Property(x => x.Size).HasColumnType("varchar(14)"); //1000x1000x1000
            builder.Property(x => x.Description).HasColumnType("varchar(50)");
        }
    }
}