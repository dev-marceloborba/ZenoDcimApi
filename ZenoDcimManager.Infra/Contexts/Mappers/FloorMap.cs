using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class FloorMap : IEntityTypeConfiguration<Floor>
    {
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            builder.ToTable("Floor");
            builder.Property(x => x.Name).HasColumnType("varchar(100)");
        }
    }
}