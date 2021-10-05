using EvoDcimManager.Shared.ValueObjects;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.ValueObjects
{
    public class BaseEquipment : ValueObject
    {
        public BaseEquipment(string name, string model, string manufactor, string serialNumber)
        {
            Name = name;
            Model = model;
            Manufactor = manufactor;
            SerialNumber = serialNumber;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrEmpty(Name, "Name", "Name is required")
                .IsNotNullOrEmpty(Model, "Model", "Model is required")
                .IsNotNullOrEmpty(Manufactor, "Manufactor", "Manufactor is required")
                .IsNotNullOrEmpty(SerialNumber, "SerialNumber", "SerialNumber is required")
            );
        }

        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Manufactor { get; private set; }
        public string SerialNumber { get; private set; }
    }
}