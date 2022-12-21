using System;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class EquipmentCardSettings : Entity
    {
        public EquipmentCardSettings()
        {
        }

        public ParameterInfo Parameter1 { get; set; }
        public ParameterInfo Parameter2 { get; set; }
        public ParameterInfo Parameter3 { get; set; }
        public Guid? EquipmentId { get; set; }
        public Equipment Equipment { get; set; }
    }
}