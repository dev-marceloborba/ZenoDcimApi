using System;

namespace ZenoDcimManager.Domain.AutomationContext.Entities
{
    public class ModbusTag : Tag
    {
        public int Address { get; private set; }
        public int Size { get; private set; }
        public string DataType { get; private set; }
        // Navigation property
        public Guid? PlcId { get; private set; }

        public ModbusTag(string name, double deadband, int address, int size, string dataType) : base(name, deadband)
        {
            Address = address;
            Size = size;
            DataType = dataType;
        }

        public void ChangeAddress(int address) => Address = address;
        public void ChangeSize(int size) => Size = size;
    }
}