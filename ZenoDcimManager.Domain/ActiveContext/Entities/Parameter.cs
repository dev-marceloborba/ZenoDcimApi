using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Parameter : Entity
    {
        public string Name{ get; private set; }
        public string Unit{ get; private set; }
        public int LowLimit{ get; private set; }
        public int HighLimit{ get; private set; }
        public int Scale{ get; private set; }
        public List<ParameterGroupAssignment> ParameterGroupAssignments { get; private set; } = new List<ParameterGroupAssignment>();

        public Parameter()
        {
        }

        public Parameter(string name, string unit, int lowLimit, int highLimit, int scale)
        {
            Name = name;
            Unit = unit;
            LowLimit = lowLimit;
            HighLimit = highLimit;
            Scale = scale;
        }

        public void AddParameter(ParameterGroupAssignment parameter)
        {
            ParameterGroupAssignments.Add(parameter);
        }

        public void RemoveParameter(ParameterGroupAssignment parameter)
        {
            ParameterGroupAssignments.Remove(parameter);
        }
    }
}
