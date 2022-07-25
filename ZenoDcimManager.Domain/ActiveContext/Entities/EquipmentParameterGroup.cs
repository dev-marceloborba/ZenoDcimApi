using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class EquipmentParameterGroup : Entity
    {
        public string Name { get; set; }
        public EEquipmentGroup Group { get; set; }
        public List<ParameterGroupAssignment> ParameterGroupAssignments { get; set; } = new List<ParameterGroupAssignment>();
    }
}

