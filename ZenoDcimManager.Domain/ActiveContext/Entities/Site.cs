using System;
using System.Collections.Generic;
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
        public SiteBuildingCardSettings CardSettings { get; set; }

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
    }
}

