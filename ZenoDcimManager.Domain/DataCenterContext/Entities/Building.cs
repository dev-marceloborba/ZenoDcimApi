using System.Collections.Generic;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.DataCenterContext.Entities
{
    public class Building : Entity
    {
        public Building(string campus, string name)
        {
            Campus = campus;
            Name = name;
        }

        public string Campus { get; private set; }
        public string Name { get; private set; }
        public List<Floor> Floors { get; private set; } = new List<Floor>();

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