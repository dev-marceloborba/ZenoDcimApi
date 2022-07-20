using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class EquipmentMap : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.ToTable("Equipment");
            builder.Property(x => x.ComponentCode).HasColumnType("varchar(30)");
            builder.Property(x => x.Description).HasColumnType("varchar(100)");
            builder.Property(x => x.Component).HasColumnType("varchar(64)");
        }
    }
}