using System;
using System.Collections.Generic;
using System.Linq;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Rack : Entity
    {
        public List<RackPosition> Slots { get; private set; }
        public int Size { get; private set; }
        public string Localization { get; private set; }

        public Rack()
        {

        }
        public Rack(int size, string localization)
        {
            Size = size;
            Localization = localization;
            Slots = new List<RackPosition>();
        }

        public void InitEmptyRack()
        {
            for (int i = 1; i <= Size; i++)
            {
                Slots.Add(new RackPosition(i, i));
            }
        }
        public void PopulateSlots(List<RackPosition> slots) => Slots = slots;
        // public void PlaceEquipment(RackPosition rackPosition)
        // {
        //     if (rackPosition.FinalPosition > rackPosition.InitialPosition)
        //     {
        //         var rangeSlots = Slots.Where(x =>
        //                 x.InitialPosition >= rackPosition.InitialPosition &&
        //                 x.FinalPosition <= rackPosition.FinalPosition)
        //             .ToList();

        //         foreach (var item in rangeSlots)
        //         {
        //             Slots.Remove(item);
        //         }
        //         Slots.Add(rackPosition);
        //     }
        // }

        public void PlaceEquipment(RackEquipment equipment, int initialPosition, int finalPosition)
        {
            if (finalPosition > initialPosition)
            {
                var rangeSlots = Slots.Where(x =>
                    x.InitialPosition >= initialPosition &&
                    x.FinalPosition <= finalPosition
                ).ToList();

                foreach (var item in rangeSlots)
                    Slots.Remove(item);

                var slot = new RackPosition(initialPosition, finalPosition);
                slot.AddEquipment(equipment);
                Slots.Add(slot);
            }
        }

        public void RemoveEquipment(int position)
        {
            var slot = Slots.Find(x => x.InitialPosition == position);
            for (int i = slot.InitialPosition; i <= slot.FinalPosition; i++)
            {
                Slots.Add(new RackPosition(i, i));
            }
            Slots.Remove(slot);
        }

        public int TotalEquipments()
        {
            var quantity = 0;
            Slots.ForEach(x =>
            {
                if (x.IsNotAvailable())
                    quantity++;

            });
            return quantity;
        }

        public int TotalOccupedSlots()
        {
            var quantity = 0;
            Slots.ForEach(x =>
            {
                if (x.IsNotAvailable())
                    quantity += x.RackUnit();
            });

            return quantity;
        }

        public int[] AvailablePositions()
        {
            var availablePositions = new List<int>();
            Slots.ForEach(x =>
            {
                if (x.IsAvailable())
                {
                    availablePositions.Add(x.InitialPosition);
                }
            });

            return availablePositions.OrderBy(x => x).ToArray();
        }

        public int[] OccupedPositions()
        {
            var occupedPositions = new List<int>();
            Slots.ForEach(x =>
            {
                if (x.IsNotAvailable())
                {
                    occupedPositions.Add(x.InitialPosition);
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
            var orderedSlots = Slots.OrderBy(x => x.InitialPosition);
            var firstAvailableSlot = orderedSlots.FirstOrDefault(x => x.IsAvailable());
            return firstAvailableSlot.InitialPosition;
        }
    }
}