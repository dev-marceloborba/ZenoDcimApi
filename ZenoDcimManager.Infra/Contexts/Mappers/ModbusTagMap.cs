using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class ModbusTagMap : IEntityTypeConfiguration<ModbusTag>
    {
        public void Configure(EntityTypeBuilder<ModbusTag> builder)
        {
            builder.ToTable("ModbusTag");
            builder.Property(x => x.DataType).HasColumnType("varchar(16)");
            builder.Property(x => x.Name).HasColumnType("varchar(50)");
            builder.Property(x => x.EquipmentParameterName).HasColumnType("varchar(50)");
        }
    }
}