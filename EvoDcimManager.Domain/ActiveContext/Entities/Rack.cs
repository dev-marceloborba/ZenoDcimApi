using System.Collections.Generic;
using EvoDcimManager.Shared;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Rack : Entity
    {
        public int Size { get; private set; }
        public string Localization { get; private set; }
        public Equipment[] Equipments { get; private set; }
        public int OccupedSlots { get; private set; } = 0;

        public Rack(int size, string localization)
        {
            Size = size;
            Localization = localization;
            Equipments = new Equipment[Size];

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Size, 0, "Size", "Should be greater then zero")
                    .IsLowerThan(Size, 60, "Size", "Size should be lower than 60")
                    .IsNotNullOrEmpty(Localization, "Localization", "Localization is required")
            );
        }

        public void AddEquipment(Equipment equipment)
        {
            if (OccupedSlots < Size)
            {
                Equipments[OccupedSlots] = equipment;
                OccupedSlots += equipment.Occupation.Value;
            }
            else
            {
                AddNotification("Equipments", "No space left");
            }
        }
        public void AddEquipment(Equipment equipment, int position)
        {
            ValidatePosition(position);
            if (Valid)
            {
                var currentPosition = position - 1;
                if (Equipments[currentPosition] != null)
                {
                    AddNotification("Equipment", "There's already an equipment on the selected slot");
                    return;
                }
                else
                {
                    Equipments[currentPosition] = equipment;
                    OccupedSlots += equipment.Occupation.Value;
                }
            }


        }
        public double RackSpaceUsage()
        {
            double usage = (double)OccupedSlots / Size;
            return usage * 100.0;
        }
        public double RackFreeSpaceUsage()
        {
            return 100 - RackSpaceUsage();
        }

        public int NextAvaiblePosition()
        {
            if (OccupedSlots == Size)
                return 0;

            return OccupedSlots + 1;
        }
        public int[] AvailablePositions()
        {
            if (OccupedSlots == Size)
                return null;

            var positions = new List<int>();
            for (int i = 0; i < Size; i++)
            {
                if (Equipments[i] == null)
                {
                    positions.Add(i + 1);
                }
            }
            return positions.ToArray();
        }

        // Remove equipment
        public void RemoveEquipment(int position, Equipment equipment)
        {
            ValidatePosition(position);
            if (Valid)
            {
                Equipments[position] = null;
                OccupedSlots -= equipment.Occupation.Value;
            }
        }

        public void UpdateEquipment(Equipment equipment, int position)
        {
            ValidatePosition(position);
            if (Valid)
                Equipments[position] = equipment;

        }

        private void ValidatePosition(int position)
        {
            if (position > Size)
                AddNotification("Equipment", "Invalid position");
        }
    }
}