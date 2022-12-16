using System;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Domain.AutomationContext.ViewModels
{
    public class ParameterInfoViewModel
    {
        public string Description { get; set; }
        // public string Pathname { get; set; }
        public bool Enabled { get; set; }
        public Guid EquipmentParameterId { get; set; }
        public EquipmentParameter EquipmentParameter { get; set; }
    }
}