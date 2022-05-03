using System;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class ParameterGroupAssignment : Entity
    {
        public EquipmentParameterGroup EquipmentParameterGroup { get; private set; }
        public Parameter Parameter { get; private set; }

        public Guid EquipmentParameterGroupId { get; private set;}
        public Guid ParameterId { get; private set;}

        public ParameterGroupAssignment()
        {
        }
    }
}
