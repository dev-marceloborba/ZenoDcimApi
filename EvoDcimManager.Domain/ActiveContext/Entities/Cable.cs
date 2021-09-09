using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using EvoDcimManager.Shared;

namespace EvoDcimManager.Domain.ActiveContext.Entities
{
    public class Cable : Entity
    {
        public int Code { get; private set; }
        public ConnectionEdge Origin { get; private set; }
        public ConnectionEdge Destination { get; private set; }
    }
}