namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class Rack : Equipment
    {
        public double TemperatureIn { get; private set; }
        public double TemperatureOut { get; private set; }
        public double Power { get; private set; }
        public bool PortStatus { get; private set; }
        public Rack(string name, string manufactor, string model) : base(name, manufactor, model)
        {
        }


    }
}