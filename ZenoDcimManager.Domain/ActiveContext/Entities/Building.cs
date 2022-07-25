using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Building : Entity
    {
        public string Name { get; set; }
        public List<Floor> Floors { get; set; } = new List<Floor>();
        // Navigation property
        public Guid? SiteId { get; set; }
    }
}