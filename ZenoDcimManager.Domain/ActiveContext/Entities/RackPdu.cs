using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class RackPdu : Entity
    {
        public RackPdu(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}