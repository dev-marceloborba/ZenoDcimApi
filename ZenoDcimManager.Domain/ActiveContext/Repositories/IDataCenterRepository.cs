using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared.UnitOfWork;

namespace ZenoDcimManager.Domain.ActiveContext.Repositories
{
    public interface IDataCenterRepository : IUnitOfWork
    {
        // Site
        public Task AddSite(Site site);
        public Task<IEnumerable<Site>> FindAllSites();
        public Task<Site> FindSiteById(Guid id);
        public void DeleteSite(Site site);

        // Building
        public Task AddBuilding(Building building);
        public Task<IEnumerable<Building>> FindAllBuildings();
        public Task<Building> FindBuildingById(Guid id);
        public void DeleteBuilding(Guid id);

        // Floor
        public Task AddFloor(Floor floor);
        public Task<IEnumerable<Floor>> FindAllFloors();
        public Task<Floor> FindFloorById(Guid id);
        public IEnumerable<Floor> FindFloorByBuilding(Guid buildingId);
        public void DeleteFloor(Floor floor);

        // Room
        public Task AddRoom(Room room);
        public Task<IEnumerable<Room>> FindAllRooms();
        public Task<Room> FindRoomById(Guid id);
        public IEnumerable<Room> FindRoomByFloor(Guid floorId);
        public void DeleteRoom(Room room);

        //Equipment
        public Task AddEquipment(Equipment equipment);
        public Task<IEnumerable<Equipment>> FindAllEquipments();
        public Task<Equipment> FindEquipmentById(Guid id);
        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId);
        public void DeleteEquipment(Equipment equipment);

        // Equipment parameter
        public Task AddEquipmentParameter(EquipmentParameter parameter);
        public Task<EquipmentParameter> FindEquipmentParameterById(Guid id);
        public Task<IEnumerable<EquipmentParameter>> FindAllEquipmentParameters();
        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id);
        public Task<IEnumerable<EquipmentParameter>> FindParametersByIdRange(Guid[] id);
        public void DeleteEquipmentParameter(EquipmentParameter parameter);

        // Equipment parameter group
        public Task AddEquipmentParameterGroup(EquipmentParameterGroup equipmentParameterGroup);
        public Task<IEnumerable<EquipmentParameterGroup>> FindAllEquipmentParameterGroups();
        public void DeleteParameterGroup(EquipmentParameterGroup equipmentParameterGroup);
        
    }
}