using System.Collections.Generic;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using EvoDcimManager.Shared;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Rack : Entity
    {
        private List<RackEquipment> _equipments;
        public int Size { get; set; }
        public string Localization { get; set; }
        public int OccupedSlots { get; set; } = 0;
        // public RackEquipment[] Equipments { get; set; }
        public IReadOnlyCollection<RackEquipment> Equipments => _equipments.ToArray();

        public Rack(int size, string localization)
        {
            Size = size;
            Localization = localization;
            _equipments = new List<RackEquipment>();
            // Equipments = new RackEquipment[Size];

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Size, 0, "Size", "Should be greater then zero")
                    .IsLowerThan(Size, 60, "Size", "Size should be lower than 60")
                    .IsNotNullOrEmpty(Localization, "Localization", "Localization is required")
            );
        }
        private void IncreaseOccupedSlot(RackEquipment equipment)
        {
            OccupedSlots += equipment.Slot.Occupation;
        }
        private void DecreaseOccupedSlot(RackEquipment equipment)
        {
            OccupedSlots -= equipment.Slot.Occupation;
        }
        public void AddEquipment(RackEquipment equipment)
        {
            ValidatePosition(equipment.Slot.Position);
            if (Valid)
            {
                // verifica se o slot está ocupado
                if (_equipments.Exists(x => x.Slot.Position == equipment.Slot.Position))
                {
                    AddNotification("Equipment", "There's already an equipment on the selected slot");
                    return;
                }
                else
                {
                    var position = equipment.Slot.Position;
                    var occupation = equipment.Slot.Occupation;

                    for (int i = 0; i < occupation; i++)
                    {
                        _equipments.Add(equipment);
                        position++;
                    }
                    IncreaseOccupedSlot(equipment);
                }
            }
        }
        // public void AddEquipment(RackEquipment equipment, int position)
        // {
        //     ValidatePosition(position);
        //     if (Valid)
        //     {
        //         var currentPosition = position - 1;
        //         if (Equipments[currentPosition] != null)
        //         {
        //             AddNotification("Equipment", "There's already an equipment on the selected slot");
        //             return;
        //         }
        //         else
        //         {
        //             var slot = currentPosition;
        //             for (int i = 0; i < equipment.Slot.Occupation; i++)
        //             {
        //                 Equipments[slot] = equipment;
        //                 slot++;
        //             }

        //             IncreaseOccupedSlot(equipment);
        //         }
        //     }
        // }
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
            // lista
            // elemento1 = 2u
            // elemento2 = 2u
            // rack=8u
            // livre: 5, 6, 7, 8
            if (OccupedSlots == Size)
                return null;

            var positions = new List<int>();
            for (int i = 1; i <= Size; i++)
            {
                // if (Equipments[i] == null)
                // if (!_equipments.Exists(x => x.Slot.Position == i))
                {
                    positions.Add(i + 1);
                }
            }
            return positions.ToArray();
        }
        public void RemoveEquipment(int position, RackEquipment equipment)
        {
            ValidatePosition(position);
            if (Valid)
            {
                // Equipments[position] = null;
                _equipments.Remove(equipment);
                DecreaseOccupedSlot(equipment);
            }
        }
        public void UpdateEquipment(RackEquipment equipment, int position)
        {
            ValidatePosition(position);
            if (Valid)
            {
                var selectedEquipment = _equipments.Find(x => x.Slot.Position == equipment.Slot.Position);
                selectedEquipment = equipment;

            }
            // Equipments[position] = equipment;

        }
        private void ValidatePosition(int position)
        {
            if (position > Size)
                AddNotification("Equipment", "Invalid position");
        }
    }
}