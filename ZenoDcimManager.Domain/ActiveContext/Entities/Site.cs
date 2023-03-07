using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared;
using ZenoDcimManager.Shared.Interfaces;

namespace ZenoDcimManager.Domain.ZenoContext.Entities

{
    public class Site : Entity,
        IPrototype<Site>,
        IDuplicate<Site>
    {
        public string Name { get; set; }
        public List<Building> Buildings { get; set; } = new List<Building>();
        public SiteCardSettings CardSettings { get; set; }

        public Site Clone()
        {
            var clone = (Site)MemberwiseClone();
            clone.SetId(Guid.NewGuid());
            return clone;
        }

        public Site Duplicate()
        {
            var duplicated = Clone();
            duplicated.Name = duplicated.Name + " - cópia";
            return duplicated;
        }

        public double GetPowerCapacity() => Buildings.Sum(x => x.GetPowerCapacity());
        public int GetRackCapacity() => Buildings.Sum(x => x.GetRackCapacity());
        public double GetOccupiedPower() => Buildings.Sum(x => x.GetOccupiedPower());
        public int GetRacksQuantity() => Buildings.Sum(x => x.GetRacksQuantity());
        public int GetRoomsQuantity() => Buildings.Sum(x => x.GetRoomsQuantity());
        public int GetOccupiedCapacity() => Buildings.Sum(x => x.GetOccupiedCapacity());
    }
}

