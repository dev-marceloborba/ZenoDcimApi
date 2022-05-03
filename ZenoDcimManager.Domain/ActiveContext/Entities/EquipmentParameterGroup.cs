using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class EquipmentParameterGroup : Entity
	{
        public string Name { get; set; }
        public EEquipmentGroup Group { get; set; }
        public List<ParameterGroupAssignment> ParameterGroupAssignments { get; set; } = new List<ParameterGroupAssignment>();
	}
}

