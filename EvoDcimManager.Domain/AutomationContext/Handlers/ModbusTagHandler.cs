using EvoDcimManager.Domain.AutomationContext.Commands;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Domain.AutomationContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.AutomationContext.Handlers
{
    public class ModbusTagHandler : Notifiable, ICommandHandler<ModbusTagCommand>
    {
        private readonly IModbusTagRepository _modbusTagRepository;

        public ModbusTagHandler(IModbusTagRepository modbusTagRepository)
        {
            _modbusTagRepository = modbusTagRepository;
        }

        public ICommandResult Handle(ModbusTagCommand command)
        {
            var modbusTag = new ModbusTag(command.Name, command.Address, command.Size);
            var modbusTagValidator = new ModbusTagValidator(modbusTag);

            AddNotifications(modbusTagValidator);

            if (Invalid)
                return new CommandResult(false, "Error on creating modbus tag", modbusTagValidator.Notifications);

            _modbusTagRepository.Save(modbusTag);
            return new CommandResult(true, "Modbus tag successful created", modbusTag);
        }
    }
}