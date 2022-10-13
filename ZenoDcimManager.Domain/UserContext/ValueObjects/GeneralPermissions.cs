using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Domain.UserContext.ValueObjects
{
    public class GeneralPermissions : ValueObject
    {
        public bool ReceiveEmail { get; set; }
        // public bool ReceiveNotifications { get; set; }

    }
}