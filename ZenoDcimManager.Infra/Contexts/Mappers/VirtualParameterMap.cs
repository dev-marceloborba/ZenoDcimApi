using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class VirtualParameterMap : IEntityTypeConfiguration<VirtualParameter>
    {
        public void Configure(EntityTypeBuilder<VirtualParameter> builder)
        {
            // builder.ToTable("VirtualParameter");
            builder.Ignore(x => x.Variables);
        }
    }
}