using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RealtimeDataMap : IEntityTypeConfiguration<RealtimeData>
    {
        public void Configure(EntityTypeBuilder<RealtimeData> builder)
        {
            builder.ToTable("RealtimeData");
        }
    }
}

