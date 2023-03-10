using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;
using ZenoDcimManager.Infra.Contexts.Conversions;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class WorkOrderEventMap : IEntityTypeConfiguration<WorkOrderEvent>
    {
        public void Configure(EntityTypeBuilder<WorkOrderEvent> builder)
        {
            builder.ToTable("WorkOrderEvent");
            builder.Ignore(x => x.ModifiedDate);
            builder.Property(x => x.User).HasColumnType("varchar(80)");
            builder.HasOne(x => x.WorkOrder).WithMany(x => x.WorkOrderEvents);
        }
    }
}