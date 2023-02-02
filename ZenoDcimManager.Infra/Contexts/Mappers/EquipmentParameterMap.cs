using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class EquipmentParameterMap : IEntityTypeConfiguration<EquipmentParameter>
    {
        public void Configure(EntityTypeBuilder<EquipmentParameter> builder)
        {
            builder.ToTable("EquipmentParameter");
            builder.Property(x => x.Name).HasColumnType("varchar(50)");
            builder.Property(x => x.DataSource).HasColumnType("varchar(20)");
            builder.Property(x => x.Unit).HasColumnType("varchar(5)");
            builder.Property(x => x.Expression).HasColumnType("varchar(200)");
            builder.Property(x => x.Pathname).HasColumnType("varchar(300)");
        }
    }
}