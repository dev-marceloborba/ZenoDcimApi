using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class SiteMap : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable("Site");
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
            builder.HasOne(x => x.CardSettings).WithOne(x => x.Site).OnDelete(DeleteBehavior.Cascade);
        }
    }
}