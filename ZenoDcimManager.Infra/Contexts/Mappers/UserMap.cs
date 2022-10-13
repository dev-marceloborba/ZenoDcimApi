using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(x => x.Id);
            builder.Property(x => x.Active);
            builder.Property(x => x.FirstName)
                .HasColumnType("varchar(80)")
                .HasColumnName("FirstName");
            builder.Property(x => x.LastName)
                .HasColumnType("varchar(80)")
                .HasColumnName("LastName");
            builder.Property(x => x.Email)
                .HasColumnType("varchar(120)")
                .HasColumnName("Email");
            builder.Property(x => x.HashedPassword)
                .HasColumnType("varchar(80)");
            builder.HasIndex(x => x.Email);
        }
    }
}