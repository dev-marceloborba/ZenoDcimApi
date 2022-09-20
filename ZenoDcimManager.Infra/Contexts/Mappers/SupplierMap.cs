using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ServiceOrderContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class SupplierMap : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Supplier");
            builder.Property(x => x.Company).HasColumnType("varchar(100)");
            builder.Property(x => x.Responsible).HasColumnType("varchar(100)");
            builder.Property(x => x.Email).HasColumnType("varchar(50)");
            builder.Property(x => x.Phone).HasColumnType("varchar(20)");
        }
    }
}