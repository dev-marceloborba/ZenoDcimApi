using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Infra.Contexts.Mappers
{
    public class ParameterGroupAssignmentMap : IEntityTypeConfiguration<ParameterGroupAssignment>
    {
        public void Configure(EntityTypeBuilder<ParameterGroupAssignment> builder)
        {
            builder.ToTable("ParameterGroupAssignment");
            builder.HasKey(
                x => new { x.ParameterId, x.EquipmentParameterGroupId });
        }
    }
}