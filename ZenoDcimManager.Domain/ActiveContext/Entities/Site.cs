using System;
using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities

{
	public class Site : Entity
	{
        public string Name { get; set; }
		public List<Building> Buildings { get; set; } = new List<Building>();
    }
}

