using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts.Conversions;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class AlarmMap : IEntityTypeConfiguration<Alarm>
    {
        public void Configure(EntityTypeBuilder<Alarm> builder)
        {
            builder.ToTable("Alarm");
            builder.Property(x => x.InDate).HasConversion(typeof(UtcValueConverter));
            builder.Property(x => x.OutDate).HasConversion(typeof(UtcValueConverter));
            builder.Property(x => x.RecognizedDate).HasConversion(typeof(UtcValueConverter));
            builder.Property(x => x.Pathname).HasColumnType("varchar(250)");
            builder.Property(x => x.AckInterval).HasConversion<long>();
            builder.Property(x => x.Operator).HasColumnType("varchar(20)");
        }
    }
}