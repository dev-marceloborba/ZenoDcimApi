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

        public void AddEquipment(Equipment equipment)
        {
            throw new System.NotImplementedException();
        }

        public void AddFloor(Building building)
        {
            foreach (var item in building.Floors)
            {
                _context.Floors.Add(item);
            }
            _context.SaveChanges();
        }

        public void AddRoom(Room room)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteBuilding(Guid id)
        {
            var building = _context.Buildings.Find(id);
            _context.Entry(building).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<Building> FindAllBuildings()
        {
            return _context.Buildings.Include(x => x.Floors).ToList();
        }

        public IEnumerable<Equipment> FindAllEquipments()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Floor> FindAllFloors()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Room> FindAllRooms()
        {
            throw new System.NotImplementedException();
        }

        public Building FindBuildingById(Guid id)
        {
            return _context.Buildings.Find(id);
        }
    }
}