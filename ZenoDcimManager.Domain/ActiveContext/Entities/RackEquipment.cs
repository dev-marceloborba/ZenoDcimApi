using System;
using ZenoDcimManager.Domain.ActiveContext.Enums;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class RackEquipment : Entity
    {
        public BaseEquipment BaseEquipment { get; private set; }
        public int InitialPosition { get; private set; }
        public int FinalPosition { get; private set; }
        public ERackEquipmentType RackEquipmentType { get; private set; }
        // Navigation property
        public Guid? RackId { get; private set; }

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