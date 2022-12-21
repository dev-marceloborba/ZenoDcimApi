using System;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;

namespace ZenoDcimManager.Domain.AutomationContext.ViewModels
{
    public class EquipmentCardViewModel
    {
        public Guid Id { get; set; }
        public Guid EquipmentId { get; set; }
        public Guid RoomId { get; set; }
        public string Name { get; set; }
        public ParameterInfo Parameter1 { get; set; }
        public ParameterInfo Parameter2 { get; set; }
        public ParameterInfo Parameter3 { get; set; }
    }
}