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
            _context.SaveChanges();
        }

        public void AddEquipment(Room room)
        {
            foreach (var equipment in room.Equipments)
            {
                _context.Equipments.Add(equipment);
            }
            _context.SaveChanges();
        }

        public void AddFloor(Building building)
        {
            foreach (var item in building.Floors)
            {
                _context.Floors.Add(item);
            }
            _context.SaveChanges();
        }

        public void AddRoom(Floor floor)
        {
            foreach (var room in floor.Rooms)
            {
                _context.Rooms.Add(room);

            }
            _context.SaveChanges();
        }

        public void DeleteBuilding(Guid id)
        {
            var building = _context.Buildings.Find(id);
            _context.Entry(building).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteEquipment(Equipment equipment)
        {
            _context.Entry(equipment).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteFloor(Floor floor)
        {
            _context.Entry(floor).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<Building> FindAllBuildings()
        {
            return _context.Buildings
                .Include(x => x.Floors)
                .ThenInclude(x => x.Rooms)
                .ThenInclude(x => x.Equipments)
                .ToList();
        }

        public IEnumerable<Equipment> FindAllEquipments()
        {
            return _context.Equipments.ToList();
        }

        public IEnumerable<Floor> FindAllFloors()
        {
            return _context.Floors
                .Include(x => x.Rooms)
                .ToList();
        }

        public IEnumerable<Room> FindAllRooms()
        {
            return _context.Rooms
                .Include(x => x.Equipments)
                .ToList();
        }

        public Building FindBuildingById(Guid id)
        {
            return _context.Buildings
                .Find(id);
        }

        public Equipment FindEquipmentById(Guid id)
        {
            return _context.Equipments.Find(id);
        }

        public Floor FindFloorById(Guid id)
        {
            return _context.Floors
                .Find(id);
        }

        public Room FindRoomById(Guid id)
        {
            return _context.Rooms.Find(id);
        }
    }
}