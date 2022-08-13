using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class History : Entity
    {
        public string Name { get; set; }
        public int Scan { get; set; }
        public List<EquipmentParameter> Parameters { get; set; }
    }
}