using System;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class RackEquipment : Entity
    {
        public BaseEquipment BaseEquipment { get; private set; }
        public int InitialPosition { get; private set; }
        public int FinalPosition { get; private set; }
        public Rack Rack { get; private set; }
        public Guid? RackId { get; private set; }

        public RackEquipment()
        {

        }
        public RackEquipment(int initialPosition, int finalPosition)
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;
        }
        public RackEquipment(BaseEquipment baseEquipment, int initialPosition, int finalPosition) : this(initialPosition, finalPosition)
        {
            BaseEquipment = baseEquipment;
        }

        public bool IsAvailable() => BaseEquipment == null;
        public bool IsNotAvailable() => BaseEquipment != null;
        public void AddEquipment(BaseEquipment equipment)
        {
            BaseEquipment = equipment;
        }


        public void AssociateRack(Rack rack)
        {
            Rack = rack;
        }

        public void AssociateRackId(Guid id)
        {
            RackId = id;
        }

        public int RackUnit() => FinalPosition - InitialPosition + 1;
    }
}