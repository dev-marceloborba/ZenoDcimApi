using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class DataCenterRepository : IDataCenterRepository
    {
        private readonly ActiveContext _context;

        public DataCenterRepository(ActiveContext context)
        {
            _context = context;
        }
        public void AddBuilding(Building building)
        {
            _context.Buildings.Add(building);
        }

        public void AddEquipment(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
        }

        public void AddEquipmentParameter(EquipmentParameter parameter)
        {
            _context.EquipmentParameters.Add(parameter);
        }

        public void AddEquipmentParameterGroup(EquipmentParameterGroup equipmentParameterGroup)
        {
            _context.EquipmentParameterGroups.Add(equipmentParameterGroup);
        }

        public void AddFloor(Floor floor)
        {
            _context.Floors.Add(floor);   
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);            
        }

        public void AddSite(Site site)
        {
            _context.Sites.Add(site);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void DeleteBuilding(Guid id)
        {
            var building = _context.Buildings.Find(id);
            _context.Entry(building).State = EntityState.Deleted;
        }

        public void DeleteEquipment(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Deleted;
        }

        public void DeleteEquipmentParameter(EquipmentParameter parameter)
        {
            _context.Entry(parameter).State = EntityState.Deleted;
        }

        public void DeleteFloor(Floor floor)
        {
            _context.Entry(floor).State = EntityState.Deleted;
        }

        public void DeleteRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Deleted;
        }

        public void DeleteSite(Site site)
        {
            _context.Entry(site).State = EntityState.Deleted;
        }

        public IEnumerable<Building> FindAllBuildings()
        {
            return _context.Buildings
                .Include(x => x.Floors.OrderBy(y => y.Name))
                .ThenInclude(x => x.Rooms.OrderBy(y => y.Name))
                .ThenInclude(x => x.Equipments.OrderBy(y => y.Description))
                .ThenInclude(x => x.EquipmentParameters.OrderBy(y => y.Name))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public IEnumerable<EquipmentParameterGroup> FindAllEquipmentParameterGroups()
        {
            return _context.EquipmentParameterGroups.ToList();
        }

        public IEnumerable<EquipmentParameter> FindAllEquipmentParameters()
        {
            return _context.EquipmentParameters
                .ToList()
                .OrderBy(x => x.Name);
        }

        public IEnumerable<Equipment> FindAllEquipments()
        {
            return _context.Equipments
                .Include(x => x.EquipmentParameters)
                .ToList();
        }

        public IEnumerable<Floor> FindAllFloors()
        {
            return _context.Floors
                .Include(x => x.Rooms.OrderBy(y => y.Name))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public IEnumerable<Room> FindAllRooms()
        {
            return _context.Rooms
                .Include(x => x.Equipments.OrderBy(y => y.Description))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public IEnumerable<Site> FindAllSites()
        {
            return _context.Sites
                .Include(x => x.Buildings)
                .OrderBy(x => x.Name)
                .ToList();
        }

        public Building FindBuildingById(Guid id)
        {
            return _context.Buildings
                .Where(x => x.Id == id)
                .Include(x => x.Floors)
                .ThenInclude(x => x.Rooms)
                .First();
        }

        public Equipment FindEquipmentById(Guid id)
        {
            return _context.Equipments
                .Where(x => x.Id == id)
                .Include(x => x.EquipmentParameters)
                .First();
        }

        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId, Guid floorId, Guid buildingId)
        {
            return _context.Buildings
                .FirstOrDefault(x => x.Id == buildingId).Floors
                .FirstOrDefault(x => x.Id == floorId).Rooms
                .FirstOrDefault(x => x.Id == roomId).Equipments;
        }

        public EquipmentParameter FindEquipmentParameterById(Guid id)
        {
            return _context.EquipmentParameters
                .First(x => x.Id == id);
        }

        public IEnumerable<Floor> FindFloorByBuilding(Guid buildingId)
        {
            return _context.Buildings
                .FirstOrDefault(x => x.Id == buildingId).Floors;
        }

        public Floor FindFloorById(Guid id)
        {
            return _context.Floors
                .Find(id);
        }

        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id)
        {
            //return _context.Equipments
            //    .Find(id).EquipmentParameters;
            return _context.Equipments
                    .Where(x => x.Id == id)
                    .Include(x => x.EquipmentParameters)                
                    .First().EquipmentParameters.OrderBy(x => x.Name);
        }

        public IEnumerable<EquipmentParameter> FindParametersByIdRange(Guid[] id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> FindRoomByFloor(Guid floorId, Guid buildingId)
        {
            return _context.Buildings
                .FirstOrDefault(x => x.Id == buildingId).Floors
                .FirstOrDefault(x => x.Id == floorId).Rooms;
        }

        public Room FindRoomById(Guid id)
        {
            return _context.Rooms
                .Find(id);
        }

        public Site FindSiteById(Guid id)
        {
            return _context.Sites.Find(id);
        }
    }
}