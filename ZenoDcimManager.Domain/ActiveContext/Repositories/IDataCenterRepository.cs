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
        public Floor FindFloorById(Guid id);
        public IEnumerable<Floor> FindFloorByBuilding(Guid buildingId);
        public void DeleteFloor(Floor floor);
        public void AddRoom(Floor floor);
        public IEnumerable<Room> FindAllRooms();
        public Room FindRoomById(Guid id);
        public IEnumerable<Room> FindRoomByFloor(Guid floorId, Guid buildingId);
        public void DeleteRoom(Room room);
        public void AddEquipment(Room room);
        public void AddEquipment(Building building);
        public IEnumerable<Equipment> FindAllEquipments();
        public Equipment FindEquipmentById(Guid id);
        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId, Guid floorId, Guid buildingId);
        public void DeleteEquipment(Equipment equipment);
    }
}