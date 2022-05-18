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
        Task AddSite(Site site);
        Task<IEnumerable<Site>> FindAllSites();
        Task<Site> FindSiteById(Guid id);
        void DeleteSite(Site site);

        // Building
        Task AddBuilding(Building building);
        Task<IEnumerable<Building>> FindAllBuildings();
        Task<Building> FindBuildingById(Guid id);
        void DeleteBuilding(Building building);

        // Floor
        Task AddFloor(Floor floor);
        Task<IEnumerable<Floor>> FindAllFloors();
        Task<Floor> FindFloorById(Guid id);
        IEnumerable<Floor> FindFloorByBuilding(Guid buildingId);
        void DeleteFloor(Floor floor);

        // Room
        Task AddRoom(Room room);
        Task<IEnumerable<Room>> FindAllRooms();
        Task<Room> FindRoomById(Guid id);
        IEnumerable<Room> FindRoomByFloor(Guid floorId);
        void DeleteRoom(Room room);

        //Equipment
        Task AddEquipment(Equipment equipment);
        Task<IEnumerable<Equipment>> FindAllEquipments();
        Task<Equipment> FindEquipmentById(Guid id);
        IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId);
        void DeleteEquipment(Equipment equipment);

        // Equipment parameter
        Task AddEquipmentParameter(EquipmentParameter parameter);
        Task<EquipmentParameter> FindEquipmentParameterById(Guid id);
        Task<IEnumerable<EquipmentParameter>> FindAllEquipmentParameters();
        IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id);
        void DeleteEquipmentParameter(EquipmentParameter parameter);

        // Equipment parameter group
        Task AddEquipmentParameterGroup(EquipmentParameterGroup equipmentParameterGroup);
        Task<IEnumerable<EquipmentParameterGroup>> FindAllEquipmentParameterGroups();
        void DeleteParameterGroup(EquipmentParameterGroup equipmentParameterGroup);

        // Parameter
        Task AddParameter(Parameter parameter);
        Task<Parameter> FindParameterById(Guid id);
        Task<IEnumerable<Parameter>> FindAllParameters();
        void DeleteParameter(Parameter parameter);

        // Customs
        Task<IEnumerable<Parameter>> FindParametersByGroup(string group);
        //Task<IEnumerable<Parameter>> FindParametersByGroup(Guid groupId);
    }
}