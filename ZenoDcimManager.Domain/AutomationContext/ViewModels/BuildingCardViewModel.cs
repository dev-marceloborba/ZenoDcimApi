using System;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Domain.AutomationContext.ViewModels
{
    public class BuildingCardViewModel
    {
        public Guid Id { get; set; }
        public Guid BuildingId { get; set; }
        public string Name { get; set; }
        public ParameterInfo Parameter1 { get; set; }
        public ParameterInfo Parameter2 { get; set; }
        public ParameterInfo Parameter3 { get; set; }
        public ParameterInfo Parameter4 { get; set; }
        public ParameterInfo Parameter5 { get; set; }
        public ParameterInfo Parameter6 { get; set; }
    }
}