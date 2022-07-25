using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class EquipmentParameterGroupMap : IEntityTypeConfiguration<EquipmentParameterGroup>
    {
        public void Configure(EntityTypeBuilder<EquipmentParameterGroup> builder)
        {
            builder.ToTable("EquipmentParameterGroup");
            builder.Property(x => x.Name).HasColumnType("varchar(30)");
        }
    }
}