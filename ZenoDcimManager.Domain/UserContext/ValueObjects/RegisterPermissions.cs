using ZenoDcimManager.Shared.ValueObjects;

namespace ZenoDcimManager.Domain.UserContext.ValueObjects
{
    public class RegisterPermissions : ValueObject
    {
        public bool Users { get; set; }
        public bool Datacenter { get; set; }
        public bool Alarms { get; set; }
        public new bool Notifications { get; set; }
        public bool Parameters { get; set; }

        public RegisterPermissions()
        {

        }
    }
}