using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class UserPreferencies : Entity
    {
        public int UserTable { get; set; } = 5;
        public int SiteTable { get; set; } = 5;
        public int BuildingTable { get; set; } = 5;
        public int RoomTable { get; set; } = 5;
        public int FloorTable { get; set; } = 5;
        public int ParameterTable { get; set; } = 5;
        public int AvailableParameterTable { get; set; } = 5;
        public int GroupParameterTable { get; set; } = 5;
        public int EquipmentTable { get; set; } = 5;
        public int RuleTable { get; set; } = 5;
        public int EquipmentParameterTable { get; set; } = 5;
        public int AlarmHistoryTable { get; set; } = 5;

    }
}