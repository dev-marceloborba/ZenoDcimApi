using System;
using System.Collections.Generic;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
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
        public Guid RoomId { get; set; }
        public int Class { get; set; }
        public string Component { get; set; }
        public string ComponentCode { get; set; }
        public string Description { get; set; }
        public EEquipmentGroup Group { get; set; }
        public int Weight { get; set; }
        public string Size { get; set; }
        public int PowerLimit { get; set; }
    }
}