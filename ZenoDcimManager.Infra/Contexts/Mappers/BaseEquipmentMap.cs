using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class BaseEquipmentMap : IEntityTypeConfiguration<BaseEquipment>
    {
        public void Configure(EntityTypeBuilder<BaseEquipment> builder)
        {
            builder.ToTable("BaseEquipment");
            builder.Property(x => x.Name).HasColumnType("varchar(30)");
            builder.Property(x => x.Model).HasColumnType("varchar(30)");
            builder.Property(x => x.Manufactor).HasColumnType("varchar(30)");
            builder.Property(x => x.SerialNumber).HasColumnType("varchar(30)");
            builder.HasIndex(x => x.Name);
        }
    }
}