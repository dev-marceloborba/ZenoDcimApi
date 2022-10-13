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
        public double Scale { get; set; }
        public string Expression { get; set; }
        public string Discriminator { get; set; }
        public List<ParameterGroupAssignment> ParameterGroupAssignments { get; set; } = new List<ParameterGroupAssignment>();

        public Parameter()
        {
        }

    }
}
