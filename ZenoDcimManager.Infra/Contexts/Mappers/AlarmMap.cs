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
            builder.Property(x => x.Name).HasColumnType("varchar(50)");
            builder.Property(x => x.MessageOn).HasColumnType("varchar(200)");
            builder.Property(x => x.MessageOff).HasColumnType("varchar(200)");
            builder.Property(x => x.TagName).HasColumnType("varchar(50)");
        }
    }
}