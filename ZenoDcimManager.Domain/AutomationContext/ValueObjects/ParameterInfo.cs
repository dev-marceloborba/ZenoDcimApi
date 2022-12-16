using System;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class ParameterInfo : ValueObject
    {
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public Guid EquipmentParameterId { get; set; }
        public EquipmentParameter EquipmentParameter { get; set; }

        public ParameterInfo() { }
    }
}