using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
            builder.Property(x => x.Description).HasColumnType("varchar(30)");
            // builder.OwnsOne(x => x.Actions)
            //     .Property(x => x.AckAlarms)
            //     .HasColumnName("ActionAckAlarms")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Actions)
            //     .Property(x => x.EditConnections)
            //     .HasColumnName("ActionEditConnections")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Registers)
            //     .Property(x => x.Users)
            //     .HasColumnName("RegisterUsers")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Registers)
            //     .Property(x => x.Parameters)
            //     .HasColumnName("RegisterParameters")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Registers)
            //     .Property(x => x.Datacenter)
            //     .HasColumnName("RegisterDatacenter")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Registers)
            //     .Property(x => x.Alarms)
            //     .HasColumnName("RegisterAlarms")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Registers)
            //     .Property(x => x.Notifications)
            //     .HasColumnName("RegisterNotifications")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Views)
            //     .Property(x => x.Alarms)
            //     .HasColumnName("ViewAlarms")
            //     .HasColumnType("bit");
            // builder.OwnsOne(x => x.Views)
            //     .Property(x => x.Parameters)
            //     .HasColumnName("ViewParameters");
            // builder.OwnsOne(x => x.Views)
            //     .Property(x => x.Equipments)
            //     .HasColumnName("ViewEquipments");
            // builder.OwnsOne(x => x.General)
            //     .Property(x => x.ReceiveEmail)
            //     .HasColumnName("ReceiveEmail")
            //     .HasColumnType("bit");
        }
    }
}