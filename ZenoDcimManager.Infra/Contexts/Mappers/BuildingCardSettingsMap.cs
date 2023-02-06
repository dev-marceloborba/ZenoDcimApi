using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class BuildingCardSettingsMap : IEntityTypeConfiguration<BuildingCardSettings>
    {
        public void Configure(EntityTypeBuilder<BuildingCardSettings> builder)
        {
            builder.ToTable("BuildingCardSettings");

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
            // parameter 4
            builder.OwnsOne(x => x.Parameter4)
                .Property(x => x.Description)
                .HasColumnName("Parameter4Description")
                .HasColumnType("varchar(30)");
            builder.OwnsOne(x => x.Parameter4)
                .Property(x => x.EquipmentParameterId)
                .HasColumnName("EquipmentParameter4Id");
            builder.OwnsOne(x => x.Parameter4)
                .Property(x => x.Enabled)
                .HasColumnName("Parameter4Enabled");
            // parameter 5
            builder.OwnsOne(x => x.Parameter5)
                .Property(x => x.Description)
                .HasColumnName("Parameter5Description")
                .HasColumnType("varchar(30)");
            builder.OwnsOne(x => x.Parameter5)
                .Property(x => x.EquipmentParameterId)
                .HasColumnName("EquipmentParameter5Id");
            builder.OwnsOne(x => x.Parameter5)
                .Property(x => x.Enabled)
                .HasColumnName("Parameter5Enabled");
            // parameter 6
            builder.OwnsOne(x => x.Parameter6)
                .Property(x => x.Description)
                .HasColumnName("Parameter6Description")
                .HasColumnType("varchar(30)");
            builder.OwnsOne(x => x.Parameter6)
                .Property(x => x.EquipmentParameterId)
                .HasColumnName("EquipmentParameter6Id");
            builder.OwnsOne(x => x.Parameter6)
                .Property(x => x.Enabled)
                .HasColumnName("Parameter6Enabled");
        }
    }
}