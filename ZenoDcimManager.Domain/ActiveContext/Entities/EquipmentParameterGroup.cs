using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class EquipmentParameterGroup : Entity
	{
        public string Name { get; private set; }
		public List<EquipmentParameter> Parameters { get; private set; } = new List<EquipmentParameter>();

		public EquipmentParameterGroup()
		{
		}

        public EquipmentParameterGroup(string name)
        {
            Name = name;
        }

        public void AddParameter(EquipmentParameter parameter)
        {
			Parameters.Add(parameter);
        }

		public void RemoveParameter(EquipmentParameter parameter)
        {
			Parameters.Remove(parameter);
        }
	}
}

