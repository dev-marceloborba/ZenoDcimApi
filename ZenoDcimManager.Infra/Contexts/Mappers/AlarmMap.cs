using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class AlarmMap : IEntityTypeConfiguration<Alarm>
    {
        public void Configure(EntityTypeBuilder<Alarm> builder)
        {
            builder.ToTable("Alarm");
            builder.Property(x => x.Pathname).HasColumnType("varchar(250)");
        }
    }
}