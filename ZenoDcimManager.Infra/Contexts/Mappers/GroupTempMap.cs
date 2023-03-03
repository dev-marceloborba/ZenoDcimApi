using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class GroupTempMap : IEntityTypeConfiguration<GroupTemp>
    {
        public void Configure(EntityTypeBuilder<GroupTemp> builder)
        {
            builder.ToTable("GroupTemp");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
            builder.Property(x => x.Description).HasColumnType("varchar(30)");
            builder.OwnsOne(x => x.Actions, a =>
            {
                a.Property(p => p.AckAlarms).HasColumnName("ActionAckAlarms");
                a.Property(p => p.EditConnections).HasColumnName("ActionEditConnections");
            });
            builder.OwnsOne(x => x.Registers, r =>
            {
                r.Property(p => p.Users).HasColumnName("RegisterUsers");
                r.Property(p => p.Parameters).HasColumnName("RegisterParameters");
                r.Property(p => p.Datacenter).HasColumnName("RegisterDatacenter");
                r.Property(p => p.Alarms).HasColumnName("RegisterAlarms");
                r.Property(p => p.Notifications).HasColumnName("RegisterNotifications");
            });
            builder.OwnsOne(x => x.Views, v =>
            {
                v.Property(p => p.Alarms).HasColumnName("ViewAlarms");
                v.Property(p => p.Equipments).HasColumnName("ViewEquipments");
                v.Property(p => p.Parameters).HasColumnName("ViewParameters");
            });
            builder.OwnsOne(x => x.General, g =>
            {
                g.Property(p => p.ReceiveEmail).HasColumnName("ReceiveEmail");
            });
        }
    }
}