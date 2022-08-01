using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class AlarmRuleMap : IEntityTypeConfiguration<AlarmRule>
    {
        public void Configure(EntityTypeBuilder<AlarmRule> builder)
        {
            builder.ToTable("AlarmRule");
            builder.Property(x => x.Name).HasColumnType("varchar(200)");
        }
    }
}