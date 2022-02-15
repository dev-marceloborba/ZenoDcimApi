using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IDataCenterRepository
    {
        public void AddBuilding(Building building);
        public IEnumerable<Building> FindAllBuildings();
        public void DeleteBuilding(Guid id);
        public void AddFloor(Floor floor);
        public IEnumerable<Floor> FindAllFloors();
        public void AddRoom(Room room);
        public IEnumerable<Room> FindAllRooms();
        public void AddEquipment(Equipment equipment);
        public IEnumerable<Equipment> FindAllEquipments();
    }
}