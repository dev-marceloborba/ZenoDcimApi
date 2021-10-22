namespace EvoDcimManager.Domain.AutomationContext.Entities
{
    public class ModbusTag : Tag
    {
        public ModbusTag(string name, double deadband, int address, int size) : base(name, deadband)
        {
            Address = address;
            Size = size;
        }

        public int Address { get; private set; }
        public int Size { get; private set; }

        public void ChangeAddress(int address) => Address = address;
        public void ChangeSize(int size) => Size = size;
    }
}