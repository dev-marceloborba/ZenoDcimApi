using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.Property(x => x.Name).HasColumnType("varchar(12)");
        }
    }
}