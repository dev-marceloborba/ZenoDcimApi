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
            builder.Property(x => x.Executor).HasColumnType("varchar(50)");
            builder.Property(x => x.Supervisor).HasColumnType("varchar(50)");
            builder.Property(x => x.Manager).HasColumnType("varchar(50)");
            builder.Property(x => x.Title).HasColumnType("varchar(50)");
            builder.Property(x => x.InitialDate).HasConversion(typeof(UtcValueConverter));
            builder.Property(x => x.FinalDate).HasConversion(typeof(UtcValueConverter));
            builder.Property(x => x.Cost).HasPrecision(18, 2);
            builder.HasMany(x => x.WorkOrderEvents).WithOne(x => x.WorkOrder);
            builder.HasOne(x => x.Site);
            builder.HasOne(x => x.Building);
            builder.HasOne(x => x.Floor);
            builder.HasOne(x => x.Room);
            builder.HasOne(x => x.Equipment);
        }
    }
}

