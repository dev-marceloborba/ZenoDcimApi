using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Domain.ZenoContext.Entities;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Outputs
{
    public class RackOutput
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Localization { get; set; }
        public string Size { get; set; }
        public int Capacity { get; set; }
        public double Power { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public Site Site { get; set; }
        public Building Building { get; set; }
        public Floor Floor { get; set; }
        public Room Room { get; set; }
        public IEnumerable<RackEquipment> RackEquipments { get; set; }
        public RackStatistics Statistics { get; set; }
        public IEnumerable<RackSlot> RackSlots { get; set; }
    }

    public class RackStatistics
    {
        public double AvailablePower { get; set; }
        public double AvailableWeight { get; set; }
        public double AvailableSpace { get; set; }
    }
}