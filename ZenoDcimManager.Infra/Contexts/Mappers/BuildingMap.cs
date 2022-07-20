using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class BuildingMap : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.ToTable("Building");
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
        }
    }
}