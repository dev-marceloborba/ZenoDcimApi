using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Domain.UserContext.ValueObjects
{
    public class ViewPermissions : ValueObject
    {
        public bool Alarms { get; set; }
        public bool Parameters { get; set; }
        public bool Equipments { get; set; }
    }
}