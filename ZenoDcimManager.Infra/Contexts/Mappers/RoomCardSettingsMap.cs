using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RoomCardSettingsMap : IEntityTypeConfiguration<RoomCardSettings>
    {
        public void Configure(EntityTypeBuilder<RoomCardSettings> builder)
        {
            builder.ToTable("RoomCardSettings");
            builder.HasIndex(x => x.RoomId).IsUnique(false);
            // parameter 1
            builder.OwnsOne(x => x.Parameter1)
                .Property(x => x.Description)
                .HasColumnName("Parameter1Description")
                .HasColumnType("varchar(30)");
            builder.OwnsOne(x => x.Parameter1)
                .Property(x => x.EquipmentParameterId)
                .HasColumnName("EquipmentParameter1Id");
            builder.OwnsOne(x => x.Parameter1)
                .Property(x => x.Enabled)
                .HasColumnName("Parameter1Enabled");
            // parameter 2
            builder.OwnsOne(x => x.Parameter2)
                .Property(x => x.Description)
                .HasColumnName("Parameter2Description")
                .HasColumnType("varchar(30)");
            builder.OwnsOne(x => x.Parameter2)
                .Property(x => x.EquipmentParameterId)
                .HasColumnName("EquipmentParameter2Id");
            builder.OwnsOne(x => x.Parameter2)
                .Property(x => x.Enabled)
                .HasColumnName("Parameter2Enabled");
            // parameter 3
            builder.OwnsOne(x => x.Parameter3)
                .Property(x => x.Description)
                .HasColumnName("Parameter3Description")
                .HasColumnType("varchar(30)");
            builder.OwnsOne(x => x.Parameter3)
                .Property(x => x.EquipmentParameterId)
                .HasColumnName("EquipmentParameter3Id");
            builder.OwnsOne(x => x.Parameter3)
                .Property(x => x.Enabled)
                .HasColumnName("Parameter3Enabled");
        }
    }
}