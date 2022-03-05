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

        public void AddEquipment(Room room)
        {
            foreach (var equipment in room.Equipments)
            {
                _context.Equipments.Add(equipment);
            }
        }

        public void AddEquipment(Building building)
        {
            foreach (var floor in building.Floors)
            {
                foreach (var room in floor.Rooms)
                {
                    foreach (var equipment in room.Equipments)
                    {
                        _context.Equipments.Add(equipment);
                    }
                }
            }
        }

        public void AddEquipmentParameter(Equipment equipment)
        {
            _context.EquipmentParameters.Add(equipment.EquipmentParameters[0]);
        }

        public void AddFloor(Building building)
        {
            foreach (var item in building.Floors)
            {
                _context.Floors.Add(item);
            }
        }

        public void AddRoom(Floor floor)
        {
            foreach (var room in floor.Rooms)
            {
                _context.Rooms.Add(room);

            }
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

        public void DeleteFloor(Floor floor)
        {
            _context.Entry(floor).State = EntityState.Deleted;
        }

        public void DeleteRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Deleted;
        }

        public IEnumerable<Building> FindAllBuildings()
        {
            return _context.Buildings
                .Include(x => x.Floors.OrderBy(y => y.Name))
                .ThenInclude(x => x.Rooms.OrderBy(y => y.Name))
                .ThenInclude(x => x.Equipments.OrderBy(y => y.Description))
                .OrderBy(x => x.Name)
                .ToList();
        }

        public IEnumerable<Equipment> FindAllEquipments()
        {
            return _context.Equipments
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
                .Find(id);
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

        public void RemoveEquipmentParameter(Equipment equipment)
        {
            throw new NotImplementedException();
        }
    }
}