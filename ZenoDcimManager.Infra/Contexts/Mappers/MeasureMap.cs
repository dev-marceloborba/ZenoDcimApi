using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class MeasureMap : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.ToTable("Measure");

            builder.Property(x => x.Name).HasColumnType("varchar(200)");
        }
    }
}