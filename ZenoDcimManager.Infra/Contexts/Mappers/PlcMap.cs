using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class PlcMap : IEntityTypeConfiguration<Plc>
    {
        public void Configure(EntityTypeBuilder<Plc> builder)
        {
            builder.ToTable("Plc");
            builder.Property(x => x.Name).HasColumnType("varchar(50)");
            builder.Property(x => x.Manufactor).HasColumnType("varchar(30)");
            builder.Property(x => x.Model).HasColumnType("varchar(30)");
            builder.Property(x => x.IpAddress).HasColumnType("varchar(15)");
        }
    }
}