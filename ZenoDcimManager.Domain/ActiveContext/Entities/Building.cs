using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Building : Entity
    {
        public string Name { get; set; }
        public List<Floor> Floors { get; set; } = new List<Floor>();
        // Navigation property
        public Guid? SiteId { get; set; }
        public Site Site { get; set; }
        public SiteBuildingCardSettings CardSettings { get; set; }

        public string GetPathname()
        {
            return Site.Name + '*' + Name;
        }
    }
}