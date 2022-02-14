using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.DataCenterContext.Entities
{
    public class Equipment : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Component { get; private set; }
    }
}