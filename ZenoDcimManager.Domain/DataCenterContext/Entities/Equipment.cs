using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Shared;

namespace ZenoDcimManager.Domain.DataCenterContext.Entities
{
    public class Equipment : Entity
    {
        public int Class { get; private set; }
        public string Component { get; private set; }
        public string ComponentCode { get; private set; }
        public string Description { get; private set; }
        public Rack Rack { get; private set; }
        public RackPdu RackPdu { get; private set; }

        public Equipment(int @class, string component, string componentCode, string description, Rack rack, RackPdu rackPdu)
        {
            Class = @class;
            Component = component;
            ComponentCode = componentCode;
            Description = description;
            Rack = rack;
            RackPdu = rackPdu;
        }
    }
}