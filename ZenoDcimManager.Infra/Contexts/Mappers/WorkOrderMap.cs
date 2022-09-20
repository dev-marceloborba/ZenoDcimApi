using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Infra.Contexts.Conversions;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
	public class WorkOrderMap : IEntityTypeConfiguration<WorkOrder>
	{
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            builder.ToTable("WorkOrder");
            builder.Property(x => x.Description).HasColumnType("varchar(400)");
            builder.Property(x => x.Responsible).HasColumnType("varchar(50)");
            builder.Property(x => x.InitialDate).HasConversion(typeof(UtcValueConverter));
            builder.Property(x => x.FinalDate).HasConversion(typeof(UtcValueConverter));
        }
    }
}

