﻿using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared;
using ZenoDcimManager.Shared.Interfaces;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Building : Entity,
        IPrototype<Building>,
        IDuplicate<Building>
    {
        public string Name { get; set; }
        public List<Floor> Floors { get; set; } = new List<Floor>();
        // Navigation property
        public Site Site { get; set; }
        public Guid? SiteId { get; set; }
        public BuildingCardSettings CardSettings { get; set; }

        public Building Clone()
        {
            var clone = (Building)MemberwiseClone();
            clone.SetId(Guid.NewGuid());
            return clone;
        }

        public Building Duplicate()
        {
            var duplicated = Clone();
            duplicated.Name = duplicated.Name + " - cópia";
            return duplicated;
        }

        public string GetPathname()
        {
            return Site.Name + '*' + Name;
        }

        public double GetPowerCapacity() => Floors.Sum(x => x.GetPowerCapacity());
        public int GetRackCapacity() => Floors.Sum(x => x.GetRackCapacity());
        public double GetOccupiedPower() => Floors.Sum(x => x.GetOccupiedPower());
        public int GetRacksQuantity() => Floors.Sum(x => x.GetRacksQuantity());
        public int GetRoomsQuantity() => Floors.Sum(x => x.GetRoomsQuantity());
        public int GetOccupiedCapacity() => Floors.Sum(x => x.GetOccupiedCapacity());
    }
}