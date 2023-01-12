using System;
using ZenoDcimManager.Domain.ZenoContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class RackEquipment : Entity
    {
        public BaseEquipment BaseEquipment { get; set; }
        public string Client { get; set; }
        public string Function { get; set; }
        public int InitialPosition { get; set; }
        public int FinalPosition { get; set; }
        public ERackEquipmentType RackEquipmentType { get; set; }
        public ERackMountType RackMountType { get; set; }
        public ERackEquipmentOrientation RackEquipmentOrientation { get; set; }
        public string Size { get; set; }
        public int Occupation { get; set; }
        public double Weight { get; set; }
        public double Power { get; set; }
        public EEquipmentStatus Status { get; set; }
        public string Description { get; set; }
        public Rack Rack { get; set; }
        // Navigation property
        public Guid? RackId { get; set; }

        public RackEquipment()
        {

        }
        public RackEquipment(int initialPosition, int finalPosition, ERackEquipmentType rackEquipmentType)
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
            RackEquipmentType = rackEquipmentType;
        }
        public RackEquipment(BaseEquipment baseEquipment, int initialPosition, int finalPosition, ERackEquipmentType rackEquipmentType) : this(initialPosition, finalPosition, rackEquipmentType)
        {
            BaseEquipment = baseEquipment;
        }

        public bool IsAvailable() => BaseEquipment == null;
        public bool IsNotAvailable() => BaseEquipment != null;

        public int RackUnit() => FinalPosition - InitialPosition + 1;
    }
}