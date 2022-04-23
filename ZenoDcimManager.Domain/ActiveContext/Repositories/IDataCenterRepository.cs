using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IDataCenterRepository : IUnitOfWork
    {
        // Site
        public void AddSite(Site site);
        public void DeleteSite(Site site);
        public IEnumerable<Site> FindAllSites();
        public Site FindSiteById(Guid id);

        // Building
        public void AddBuilding(Building building);
        public IEnumerable<Building> FindAllBuildings();
        public Building FindBuildingById(Guid id);
        public void DeleteBuilding(Guid id);

        // Floor
        public void AddFloor(Floor floor);
        public IEnumerable<Floor> FindAllFloors();
        public Floor FindFloorById(Guid id);
        public IEnumerable<Floor> FindFloorByBuilding(Guid buildingId);

        // Room
        public void AddRoom(Room room);
        public void DeleteFloor(Floor floor);
        public IEnumerable<Room> FindAllRooms();
        public Room FindRoomById(Guid id);
        public IEnumerable<Room> FindRoomByFloor(Guid floorId, Guid buildingId);
        public void DeleteRoom(Room room);

        //Equipment
        public void AddEquipment(Equipment equipment);
        public IEnumerable<Equipment> FindAllEquipments();
        public Equipment FindEquipmentById(Guid id);
        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId, Guid floorId, Guid buildingId);
        public void DeleteEquipment(Equipment equipment);

        // Equipment parameter
        public void AddEquipmentParameter(EquipmentParameter parameter);
        public EquipmentParameter FindEquipmentParameterById(Guid id);
        public IEnumerable<EquipmentParameter> FindAllEquipmentParameters();
        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id);
        public IEnumerable<EquipmentParameter> FindParametersByIdRange(Guid[] id);
        public void DeleteEquipmentParameter(EquipmentParameter parameter);

        // Equipment parameter group
        public void AddEquipmentParameterGroup(EquipmentParameterGroup equipmentParameterGroup);
        public IEnumerable<EquipmentParameterGroup> FindAllEquipmentParameterGroups();
        
    }
}