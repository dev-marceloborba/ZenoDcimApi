using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities

{
	public class Site : Entity
	{
        public string Name { get; private set; }
		public List<Building> Buildings { get; private set; } = new List<Building>();

        public Site()
		{
		}

        public Site(string name)
        {
            Name = name;
        }

        public void AddBuilding(Building building)
        {
            Buildings.Add(building);
        }

        public void RemoveBuilding(Building building)
        {
            Buildings.Remove(building);
        }
    }
}

