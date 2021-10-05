using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class RackPosition : ValueObject
    {
        public RackEquipment Equipment { get; private set; }
        public int InitialPosition { get; private set; }
        public int FinalPosition { get; private set; }

        public RackPosition()
        {

        }
        public RackPosition(int initialPosition, int finalPosition)
        {
            InitialPosition = initialPosition;
            FinalPosition = finalPosition;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(InitialPosition >= FinalPosition, "InitialPosition", "Initial position should be equal or lower than final position")
            );
        }
        public RackPosition(RackEquipment equipment, int initialPosition, int finalPosition) : this(initialPosition, finalPosition)
        {
            Equipment = equipment;
        }

        public bool IsAvailable() => Equipment == null;
        public bool IsNotAvailable() => Equipment != null;
        public void AddEquipment(RackEquipment equipment) => Equipment = equipment;
        public void RemoveEquipment() => Equipment = null;
        public int RackUnit() => FinalPosition - InitialPosition + 1;
    }
}