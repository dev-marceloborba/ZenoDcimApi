using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ActiveContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ActiveContext.Commands.Inputs
{
    public class CreateMultipleEquipmentsCommand : ICommand
    {
        public IEnumerable<MultpleEquipmentsCommand> Equipments { get; set; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class MultpleEquipmentsCommand
    {
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public Guid RoomId { get; set; }
        public int Class { get; set; }
        public string Component { get; set; }
        public string ComponentCode { get; set; }
        public string Description { get; set; }
        public EEquipmentGroup Group { get; set; }
        public EEquipmentStatus Status { get; set; }
        public int Alarms { get; set; }
    }
}