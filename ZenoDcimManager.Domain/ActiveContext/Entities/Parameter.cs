using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Parameter : Entity
    {
        public string Name { get; set; }
        public string Unit { get; set; }
        public int LowLimit { get; set; }
        public int HighLimit { get; set; }
        public int Scale { get; set; }
        public List<ParameterGroupAssignment> ParameterGroupAssignments { get; set; } = new List<ParameterGroupAssignment>();

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
