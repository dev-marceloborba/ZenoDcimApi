using System;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.ZenoContext.Commands
{
    public class CreateRackEquipmentCommand : ICommand
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufactor { get; set; }
        public string SerialNumber { get; set; }
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
        public ERackEquipmentType RackEquipmentType { get; set; }
        public ERackMountType RackMountType { get; set; }
        public ERackEquipmentOrientation RackEquipmentOrientation { get; set; }
        public string Size { get; set; }
        public string Client { get; set; }
        public string Function { get; set; }
        public int Occupation { get; set; }
        public double Weight { get; set; }
        public EEquipmentStatus Status { get; set; }
        public string Description { get; set; }
        public Guid RackId { get; set; }
        public void Validate()
        {

        }
    }
}