using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class CompanyMap : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("company");
            builder.Property(x => x.CompanyName)
                .HasColumnType("varchar(80)");
            builder.Property(x => x.TradingName)
                .HasColumnType("varchar(80)");
            builder.Property(x => x.RegistrationNumber)
                .HasColumnType("varchar(14)");
        }
    }
}