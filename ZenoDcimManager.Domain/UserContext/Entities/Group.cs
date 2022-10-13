using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class Group : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        // Actions
        public bool ActionEditConnections { get; set; }
        public bool ActionAckAlarms { get; set; }
        // Registers
        public bool RegisterUsers { get; set; }
        public bool RegisterDatacenter { get; set; }
        public bool RegisterAlarms { get; set; }
        public bool RegisterNotifications { get; set; }
        public bool RegisterParameters { get; set; }
        // Views
        public bool ViewAlarms { get; set; }
        public bool ViewParameters { get; set; }
        public bool ViewEquipments { get; set; }
        // General
        public bool ReceiveEmail { get; set; }
    }
}