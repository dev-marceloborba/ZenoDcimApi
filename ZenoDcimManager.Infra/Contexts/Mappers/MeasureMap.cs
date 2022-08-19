using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Infra.Contexts.Conversions;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class MeasureMap : IEntityTypeConfiguration<Measure>
    {
        public void Configure(EntityTypeBuilder<Measure> builder)
        {
            builder.ToTable("Measure");

            builder.Property(x => x.Name).HasColumnType("varchar(200)");

            builder.Property(x => x.Timestamp).HasConversion(typeof(UtcValueConverter));
        }
    }
}