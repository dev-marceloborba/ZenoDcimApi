using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.Property(x => x.Name).HasColumnType("varchar(200)");
            builder.HasOne(x => x.CardSettings).WithOne(x => x.Room).OnDelete(DeleteBehavior.Cascade);
        }
    }
}