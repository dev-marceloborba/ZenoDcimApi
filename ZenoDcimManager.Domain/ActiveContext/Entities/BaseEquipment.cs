using ZenoDcimManager.Shared;
using Flunt.Validations;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class BaseEquipment : Entity
    {
        public BaseEquipment()
        {

        }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Manufactor { get; set; }
        public string SerialNumber { get; set; }
        public int Size { get; set; }
    }
}