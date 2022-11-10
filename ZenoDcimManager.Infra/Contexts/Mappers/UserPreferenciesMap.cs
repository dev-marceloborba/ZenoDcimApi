using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.UserContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class UserPreferenciesMap : IEntityTypeConfiguration<UserPreferencies>
    {
        public void Configure(EntityTypeBuilder<UserPreferencies> builder)
        {
            builder.ToTable("UserPreferencies");
        }
    }
}