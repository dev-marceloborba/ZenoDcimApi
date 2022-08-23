using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class ParameterMap : IEntityTypeConfiguration<Parameter>
    {
        public void Configure(EntityTypeBuilder<Parameter> builder)
        {
            builder.ToTable("Parameter");
            builder.Property(x => x.Name).HasColumnType("varchar(30)");
            builder.Property(x => x.Unit).HasColumnType("varchar(5)");
            //builder.Ignore(x => x.Expression);
            builder.Property(x => x.Expression).HasColumnType("varchar(200)");
        }
    }
}