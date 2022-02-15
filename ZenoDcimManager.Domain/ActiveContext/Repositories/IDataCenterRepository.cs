using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IDataCenterRepository
    {
        public void AddBuilding(Building building);
        public IEnumerable<Building> FindAllBuildings();
        public Building FindBuildingById(Guid id);
        public void DeleteBuilding(Guid id);
        public void AddFloor(Building building);
        public IEnumerable<Floor> FindAllFloors();
        public void AddRoom(Room room);
        public IEnumerable<Room> FindAllRooms();
        public void AddEquipment(Equipment equipment);
        public IEnumerable<Equipment> FindAllEquipments();
    }
}