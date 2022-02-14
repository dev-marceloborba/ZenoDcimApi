using System.Collections.Generic;
using ZenoDcimManager.Domain.DataCenterContext.Entities;

namespace ZenoDcimManager.Domain.DataCenterContext.Repositories
{
    public interface IDataCenterRepository
    {
        public void AddBuilding(Building building);
        public IEnumerable<Building> FindAllBuildings();
        public void AddFloor(Floor floor);
        public IEnumerable<Floor> FindAllFloors();
        public void AddRoom(Room room);
        public IEnumerable<Room> FindAllRooms();
        public void AddEquipment(Equipment equipment);
        public IEnumerable<Equipment> FindAllEquipments();
    }
}