using System;
using System.Collections.Generic;
using System.Linq;
using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Rack : Entity
    {
        public int Weight { get; set; }
        public int Size { get; set; }
        public string Localization { get; set; }
        public List<RackEquipment> RackEquipments { get; private set; }
        // navigation properties
        public Site Site { get; set; }
        public Guid? SiteId { get; set; }
        public Building Building { get; set; }
        public Guid? BuildingId { get; set; }
        public Floor Floor { get; set; }
        public Guid? FloorId { get; set; }
        public Room Room { get; set; }
        public Guid? RoomId { get; set; }

        public Rack()
        {

        }

        public Rack(int size, string localization)
        {
            Size = size;
            Localization = localization;
            RackEquipments = new List<RackEquipment>();
        }

        public void PlaceEquipment(RackEquipment equipment)
        {
            if (equipment.FinalPosition > equipment.InitialPosition)
            {
                var rangeSlots = RackEquipments.Where(x =>
                    x.InitialPosition >= equipment.InitialPosition &&
                    x.FinalPosition <= equipment.FinalPosition
                ).ToList();

                foreach (var item in rangeSlots)
                    RackEquipments.Remove(item);

                RackEquipments.Add(equipment);
            }
        }

        public void AddEquipment(RackEquipment equipment)
        {
            RackEquipments.Add(equipment);
        }

        public void RemoveEquipment(int position)
        {
            var rackPosition = RackEquipments.Find(x => x.InitialPosition == position);
            RackEquipments.Remove(rackPosition);
        }

        public int TotalEquipments()
        {
            var quantity = 0;
            RackEquipments.ForEach(x =>
            {
                if (x.IsNotAvailable())
                    quantity++;

            });
            return quantity;
        }

        public int TotalOccupedSlots()
        {
            var quantity = 0;
            RackEquipments.ForEach(x =>
            {
                if (x.IsNotAvailable())
                    quantity += x.RackUnit();
            });

            return quantity;
        }

        public int[] AvailablePositions()
        {
            var orderedSlots = RackEquipments.OrderBy(x => x.InitialPosition).ToList();
            var occuppedSlots = new List<int>();
            var allSlots = new List<int>();

            for (int i = 1; i <= Size; i++)
            {
                allSlots.Add(i);
            }

            foreach (var item in orderedSlots)
            {
                for (int i = item.InitialPosition; i < item.FinalPosition + 1; i++)
                {
                    occuppedSlots.Add(i);
                }
            }

            return allSlots.Except(occuppedSlots).ToArray();
        }

        public int[] OccupedPositions()
        {
            var occupedPositions = new List<int>();
            RackEquipments.ForEach(x =>
            {
                if (x.IsNotAvailable())
                {
                    for (int i = x.InitialPosition; i < x.FinalPosition + 1; i++)
                    {
                        occupedPositions.Add(i);
                    }
                }
            });
            return occupedPositions.ToArray();
        }

        public double PercentUsedSpace()
        {
            var totalSlots = TotalOccupedSlots();
            return (double)totalSlots / Size * 100;
        }

        public double PercentAvailableSpace()
        {
            return (double)100.0 - PercentUsedSpace();
        }

        public int FirstAvailablePosition()
        {
            return AvailablePositions()[0];
        }

        public int TotalAvailableSpace()
        {
            return AvailablePositions().Count();
        }

        public int TotalUsedSpace()
        {
            return Size - TotalAvailableSpace();
        }

        public IEnumerable<RackSlot> GetRackSlots()
        {
            var slots = new List<RackSlot>();

            for (int i = 1; i <= Size; i++)
            {
                var eq = RackEquipments.FirstOrDefault(x => i >= x.InitialPosition && i <= x.FinalPosition);
                if (eq == null)
                {
                    slots.Add(new RackSlot
                    {
                        InitialPosition = i,
                        FinalPosition = i
                    });
                }
                else
                {
                    if (!slots.Exists(x => i >= x.InitialPosition && i <= x.FinalPosition))
                    {
                        slots.Add(new RackSlot
                        {
                            Description = eq.BaseEquipment.Name,
                            InitialPosition = eq.InitialPosition,
                            FinalPosition = eq.FinalPosition,
                            EquipmentId = eq.Id
                        });
                    }
                }
            }

            return slots.OrderBy(x => x.InitialPosition);
        }

        public void ChangeLocalization(string localization) => Localization = localization;
        public void ChangeSize(int size) => Size = size;

        public int GetEquipmentCounterByTipe(ERackEquipmentType rackEquipmentType)
        {
            return RackEquipments.Where(x => x.RackEquipmentType == rackEquipmentType).Count();
        }
    }
}