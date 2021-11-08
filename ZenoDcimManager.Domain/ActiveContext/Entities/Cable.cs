using ZenoDcimManager.Domain.ActiveContext.ValueObjects;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.ActiveContext.Entities
{
    public class Cable : Entity
    {
        public int Code { get; private set; }
        public ConnectionEdge Origin { get; private set; }
        public ConnectionEdge Destination { get; private set; }
    }
}