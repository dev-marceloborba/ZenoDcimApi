using System;
using ZenoDcimManager.Shared.Commands;

namespace ZenoDcimManager.Domain.UserContext.Commands.Input
{
    public class UserPreferencesEditorCommand : ICommand
    {
        public Guid Id { get; set; }
        public int UserTable { get; set; }
        public int SiteTable { get; set; }
        public int BuildingTable { get; set; }
        public int RoomTable { get; set; }
        public int ParameterTable { get; set; }
        public int AvailableParameterTable { get; set; }
        public int GroupParameterTable { get; set; }
        public int EquipmentTable { get; set; }
        public int RuleTable { get; set; }
        public int EquipmentParameterTable { get; set; }
        public int AlarmHistoryTable { get; set; }
        public void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}