using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ZenoDcimManager.Domain.DataCenterContext.Entities;
using ZenoDcimManager.Domain.DataCenterContext.Repositories;
using ZenoDcimManager.Infra.Contexts;

namespace ZenoDcimManager.Infra.Repositories
{
    public class DataCenterRepository : IDataCenterRepository
    {
        private readonly DataCenterContext _context;
        public void AddBuilding(Building building)
        {
            _context.Buildings.Add(building);
        }

        public void AddEquipment(Equipment equipment)
        {
            throw new System.NotImplementedException();
        }

        public void AddFloor(Floor floor)
        {
            throw new System.NotImplementedException();
        }

        public void AddRoom(Room room)
        {
            throw new System.NotImplementedException();
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
    }
}