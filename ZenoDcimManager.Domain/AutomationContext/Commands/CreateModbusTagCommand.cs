using ZenoDcimManager.Shared.Commands;
using Flunt.Notifications;
using ZenoDcimManager.Domain.AutomationContext.Enums;

namespace ZenoDcimManager.Domain.AutomationContext.Commands
{
    public class CreateModbusTagCommand : Notifiable, ICommand
    {
        public string ModbusDevice { get; set; }
        public string Name { get; set; }
        public int Address { get; set; }
        public int DataSize { get; set; }
        public double Deadband { get; set; }
        public EDataType DataType { get; set; }
        public ERegisterType RegisterType { get; set; }
        public int Scan { get; set; }

        public void Validate()
        {
 
        }
    }
}