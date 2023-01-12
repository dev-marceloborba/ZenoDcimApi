using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RackEquipmentMap : IEntityTypeConfiguration<RackEquipment>
    {
        public void Configure(EntityTypeBuilder<RackEquipment> builder)
        {
            builder.ToTable("RackEquipment");
            builder.Property(x => x.Client).HasColumnType("varchar(30)");
            builder.Property(x => x.Function).HasColumnType("varchar(30)");
            builder.Property(x => x.Size).HasColumnType("varchar(14)");
            builder.Property(x => x.Description).HasColumnType("varchar(50)");
            builder
                .HasOne<Rack>(x => x.Rack)
                .WithMany(x => x.RackEquipments)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}