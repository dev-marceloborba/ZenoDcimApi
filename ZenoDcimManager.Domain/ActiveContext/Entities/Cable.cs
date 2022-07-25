using ZenoDcimManager.Domain.ZenoContext.ValueObjects;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ZenoContext.Entities
{
    public class Cable : Entity
    {
        public int Code { get; private set; }
        public ConnectionEdge Origin { get; private set; }
        public ConnectionEdge Destination { get; private set; }
    }
}