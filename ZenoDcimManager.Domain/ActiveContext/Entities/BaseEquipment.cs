using ZenoDcimManager.Shared;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class BaseEquipment : Entity
    {
        public BaseEquipment(string name, string model, string manufactor, string serialNumber)
        {
            Name = name;
            Model = model;
            Manufactor = manufactor;
            SerialNumber = serialNumber;
        }

        public string Name { get; private set; }
        public string Model { get; private set; }
        public string Manufactor { get; private set; }
        public string SerialNumber { get; private set; }
    }
}