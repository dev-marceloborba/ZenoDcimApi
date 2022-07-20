using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RackEquipmentMap : IEntityTypeConfiguration<RackEquipment>
    {
        public void Configure(EntityTypeBuilder<RackEquipment> builder)
        {
            builder.ToTable("RackEquipment");
        }
    }
}