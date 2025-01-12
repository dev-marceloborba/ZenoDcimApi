using System;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands.Inputs
{
    public class CreateEquipmentCommand : ICommand
    {
        public Guid SiteId { get; set; }
        public Guid BuildingId { get; set; }
        public Guid FloorId { get; set; }
        public Guid RoomId { get; set; }
        public string Component { get; set; }
        public string ComponentCode { get; set; }
        public string Description { get; set; }
        public EEquipmentGroup Group { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
        public double PowerLimit { get; set; }
        public string Manufactor { get; set; }
        public EEquipmentStatus Status { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}