using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IDataCenterRepository : IUnitOfWork
    {
        // Building
        public void AddBuilding(Building building);
        public IEnumerable<Building> FindAllBuildings();
        public Building FindBuildingById(Guid id);
        public void DeleteBuilding(Guid id);

        // Floor
        public void AddFloor(Building building);
        public IEnumerable<Floor> FindAllFloors();
        public Floor FindFloorById(Guid id);
        public IEnumerable<Floor> FindFloorByBuilding(Guid buildingId);

        // Room
        public void DeleteFloor(Floor floor);
        public void AddRoom(Floor floor);
        public IEnumerable<Room> FindAllRooms();
        public Room FindRoomById(Guid id);
        public IEnumerable<Room> FindRoomByFloor(Guid floorId, Guid buildingId);
        public void DeleteRoom(Room room);

        //Equipment
        public void AddEquipment(Room room);
        public void AddEquipment(Building building);
        public IEnumerable<Equipment> FindAllEquipments();
        public Equipment FindEquipmentById(Guid id);
        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId, Guid floorId, Guid buildingId);
        public void DeleteEquipment(Equipment equipment);
        public void AddEquipmentParameter(Equipment equipment);
        public EquipmentParameter FindEquipmentParameterById(Guid id);
        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id);
        public void DeleteEquipmentParameter(EquipmentParameter parameter);

        // EquipmentParameterGroup
        public void AddEquipmentParameterGroup(EquipmentParameterGroup equipmentParameterGroup);
        public IEnumerable<EquipmentParameterGroup> FindAllEquipmentParameterGroups();
    }
}