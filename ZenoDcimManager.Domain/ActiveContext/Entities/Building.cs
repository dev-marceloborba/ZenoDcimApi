using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Building : Entity
    {
        public string Campus { get; private set; }
        public string Name { get; private set; }
        public List<Floor> Floors { get; private set; } = new List<Floor>();
        // Navigation property
        public Guid SiteId { get; private set; }

        public Building() { }

        public Building(string campus, string name, Guid siteId)
        {
            Campus = campus;
            Name = name;
            SiteId = siteId;
        }

        public void AddFloor(Floor floor)
        {
            Floors.Add(floor);
        }

        public void RemoveFloor(Floor floor)
        {
            Floors.Remove(floor);
        }

        public void UpdateFloor(Floor floor)
        {
            var selectedFloor = Floors.Find(x => x.Id == floor.Id);
        }
    }
}