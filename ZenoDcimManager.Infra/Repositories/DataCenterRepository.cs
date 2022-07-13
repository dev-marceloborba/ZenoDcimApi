using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task AddBuilding(Building building)
        {
            await _context.Buildings.AddAsync(building);
        }

        public async Task AddEquipment(Equipment equipment)
        {
            await _context.Equipments.AddAsync(equipment);
        }

        public async Task AddEquipmentParameter(EquipmentParameter parameter)
        {
            await _context.EquipmentParameters.AddAsync(parameter);
        }

        public async Task AddEquipmentParameterGroup(EquipmentParameterGroup equipmentParameterGroup)
        {
            await _context.EquipmentParameterGroups.AddAsync(equipmentParameterGroup);
        }

        public async Task AddFloor(Floor floor)
        {
            await _context.Floors.AddAsync(floor);
        }

        public async Task AddParameter(Parameter parameter)
        {
            await _context.Parameters.AddAsync(parameter);
        }

        public async Task AddRoom(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        public async Task AddSite(Site site)
        {
            await _context.Sites.AddAsync(site);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void DeleteBuilding(Building building)
        {
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

        public void DeleteParameter(Parameter parameter)
        {
            _context.Entry(parameter).State = EntityState.Deleted;
        }

        public void DeleteParameterGroup(EquipmentParameterGroup equipmentParameterGroup)
        {
            _context.Entry(equipmentParameterGroup).State = EntityState.Deleted;
        }

        public void DeleteRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Deleted;
        }

        public void DeleteSite(Site site)
        {
            _context.Entry(site).State = EntityState.Deleted;
        }

        public async Task<IEnumerable<Building>> FindAllBuildings()
        {
            return await _context.Buildings
                .Include(x => x.Floors.OrderBy(y => y.Name))
                .ThenInclude(x => x.Rooms.OrderBy(y => y.Name))
                .ThenInclude(x => x.Equipments.OrderBy(y => y.Description))
                .ThenInclude(x => x.EquipmentParameters.OrderBy(y => y.Name))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<EquipmentParameterGroup>> FindAllEquipmentParameterGroups()
        {
            return await _context.EquipmentParameterGroups
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<EquipmentParameter>> FindAllEquipmentParameters()
        {
            return await _context.EquipmentParameters
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Equipment>> FindAllEquipments()
        {
            return await _context.Equipments
                .Include(x => x.EquipmentParameters)
                .ToListAsync();
        }

        public async Task<IEnumerable<Floor>> FindAllFloors()
        {
            return await _context.Floors
                .Include(x => x.Rooms.OrderBy(y => y.Name))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Parameter>> FindAllParameters()
        {
            return await _context.Parameters
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> FindAllRooms()
        {
            return await _context.Rooms
                .Include(x => x.Equipments.OrderBy(y => y.Description))
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<IEnumerable<Site>> FindAllSites()
        {
            return await _context.Sites
                .Include(x => x.Buildings)
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Building> FindBuildingById(Guid id)
        {
            return await _context.Buildings
                .Where(x => x.Id == id)
                .Include(x => x.Floors)
                .ThenInclude(x => x.Rooms)
                .FirstAsync();
        }

        public async Task<Equipment> FindEquipmentById(Guid id)
        {
            return await _context.Equipments
                .Where(x => x.Id == id)
                .Include(x => x.EquipmentParameters)
                .FirstAsync();
        }

        public IEnumerable<Equipment> FindEquipmentByRoom(Guid roomId)
        {
            return _context.Rooms
                .FirstOrDefault(x => x.Id == roomId).Equipments;
        }

        public async Task<EquipmentParameter> FindEquipmentParameterById(Guid id)
        {
            return await _context.EquipmentParameters
                .FirstAsync(x => x.Id == id);
        }

        public async Task<EquipmentParameterGroup> FindEquipmentParameterGroupById(Guid id)
        {
            return await _context.EquipmentParameterGroups
                .Where(x => x.Id == id)
                .Include(x => x.ParameterGroupAssignments)
                .SingleAsync();
        }

        public IEnumerable<Floor> FindFloorByBuilding(Guid buildingId)
        {
            return _context.Buildings
                .FirstOrDefault(x => x.Id == buildingId).Floors;
        }

        public async Task<Floor> FindFloorById(Guid id)
        {
            return await _context.Floors
                .FindAsync(id);
        }

        public async Task<Parameter> FindParameterById(Guid id)
        {
            return await _context.Parameters
                .FindAsync(id);
        }

        public IEnumerable<EquipmentParameter> FindParametersByEquipmentId(Guid id)
        {
            return _context.Equipments
                    .Where(x => x.Id == id)
                    .Select(x => x.EquipmentParameters)
                    .First()
                    .OrderBy(x => x.Name)
                    .ToList();
        }

        public async Task<IEnumerable<Parameter>> FindParametersByGroup(string groupName)
        {

            //var result = await _context.Parameters
            //    .FromSqlRaw("SELECT Parameter.Id, Parameter.Name, Parameter.Unit, Parameter.HighLimit, Parameter.LowLimit, Parameter.Scale, Parameter.CreatedDate, Parameter.ModifiedDate " +
            //                "FROM ParameterGroupAssignment " +
            //                "LEFT JOIN Parameter ON ParameterGroupAssignment.ParameterId = Parameter.Id " +
            //                "LEFT JOIN EquipmentParameterGroup ON ParameterGroupAssignment.EquipmentParameterGroupId = EquipmentParameterGroup.Id " +
            //                "WHERE EquipmentParameterGroup.Name = {0}", group)
            //    .ToListAsync();

            var parametersByGroup =
                from pga in _context.ParameterGroupAssignments
                join p in _context.Parameters on pga.ParameterId equals p.Id
                join epg in _context.EquipmentParameterGroups on pga.EquipmentParameterGroupId equals epg.Id
                where epg.Name == groupName
                //where epg.Name.Contains(groupName)
                select p;

            return await parametersByGroup.ToListAsync();
        }

        public IEnumerable<Room> FindRoomByFloor(Guid floorId)
        {
            return _context.Floors
                .FirstOrDefault(x => x.Id == floorId).Rooms;
        }

        public async Task<Room> FindRoomById(Guid id)
        {
            return await _context.Rooms
                .Where(x => x.Id == id)
                .Include(x => x.Equipments)
                .ThenInclude(x => x.EquipmentParameters)
                .FirstOrDefaultAsync();
        }

        public async Task<Site> FindSiteById(Guid id)
        {
            return await _context.Sites.FindAsync(id);
        }

        public void UpdateParameterGroup(EquipmentParameterGroup equipmentParameterGroup)
        {
            // _context.Entry(equipmentParameterGroup).State = EntityState.Modified;
            // _context.Entry(equipmentParameterGroup).State = EntityState.Added;
            _context.Entry(equipmentParameterGroup).State = EntityState.Detached;
        }
    }
}