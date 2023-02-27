using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class EquipmentMap : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");
            builder.Property(x => x.ComponentCode)
                .HasColumnName("SerialNumber")
                .HasColumnType("varchar(30)");
            builder.Property(x => x.Description).HasColumnType("varchar(100)");
            builder.Property(x => x.Component)
                .HasColumnName("Name")
                .HasColumnType("varchar(64)");
            builder.Property(x => x.Size).HasColumnType("varchar(14)"); //1000x1000x1000
            builder.Property(x => x.Manufactor).HasColumnType("varchar(20)");
            builder.HasOne(x => x.CardSettings).WithOne(x => x.Equipment).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.EquipmentParameters).WithOne(x => x.Equipment).OnDelete(DeleteBehavior.Cascade);
        }
    }
}