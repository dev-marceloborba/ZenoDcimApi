using ZenoDcimManager.Domain.UserContext.ValueObjects;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.UserContext.Entities
{
    public class GroupTemp : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ActionPermissions Actions { get; set; }
        public RegisterPermissions Registers { get; set; }
        public ViewPermissions Views { get; set; }
        public GeneralPermissions General { get; set; }

        public GroupTemp()
        {

        }

    }
}