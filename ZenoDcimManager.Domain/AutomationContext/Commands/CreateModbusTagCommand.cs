using ZenoDcimManager.Shared.Commands;
using Flunt.Notifications;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreateModbusTagCommand : Notifiable, ICommand
    {
        public string ModbusDevice { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public int Size { get; set; }
        public double Deadband { get; set; }
        public string DataType { get; set; }
        public void Validate()
        {
            if (DataType != "Coil" && DataType != "Holding Register")
            {
                AddNotification("DataType", "Invalid data type");
            }
        }
    }
}