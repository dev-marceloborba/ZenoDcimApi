using System;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class BuildingCardSettings : Entity
    {
        public BuildingCardSettings()
        {
        }

        public Guid BuildingId { get; set; }
        public Building Building { get; set; }
        public ParameterInfo Parameter1 { get; set; }
        public ParameterInfo Parameter2 { get; set; }
        public ParameterInfo Parameter3 { get; set; }
        public ParameterInfo Parameter4 { get; set; }
        public ParameterInfo Parameter5 { get; set; }
        public ParameterInfo Parameter6 { get; set; }


    }
}