using System;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class ParameterGroupAssignment : Entity
    {
        public EquipmentParameterGroup EquipmentParameterGroup { get; set; }
        public Parameter Parameter { get; set; }

        public Guid EquipmentParameterGroupId { get; set; }
        public Guid ParameterId { get; set; }

        public ParameterGroupAssignment()
        {
        }
    }
}
