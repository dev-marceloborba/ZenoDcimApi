using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Domain.UserContext.ValueObjects
{
    public class ActionPermissions : ValueObject
    {
        public bool EditConnections { get; set; }
        public bool AckAlarms { get; set; }
    }
}