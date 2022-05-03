using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZenoDcimManager.Domain.AutomationContext.Handlers
{
    public class ModbusTagHandler :
        Notifiable,
        ICommandHandler<CreateModbusTagCommand>,
        ICommandHandler<EditModbusTagCommand>,
        ICommandHandler<DeleteModbusTagCommand>,
        ICommandHandler<CreateMultipleModbusTagCommand>
    {
        private readonly IModbusTagRepository _modbusTagRepository;
        private readonly IPlcRepository _plcRepository;

        public ModbusTagHandler(IModbusTagRepository modbusTagRepository, IPlcRepository plcRepository)
        {
            _modbusTagRepository = modbusTagRepository;
            _plcRepository = plcRepository;
        }

        public async Task<ICommandResult> Handle(CreateModbusTagCommand command)
        {
            command.Validate();

            var modbusTag = new ModbusTag() {
                    Name = command.Name,
                    Address = command.Address,
                    DataSize = command.DataSize,
                    DataType = command.DataType,
                    Deadband = command.Deadband
            };

            var modbusTagValidator = new ModbusTagValidator(modbusTag);

            AddNotifications(command, modbusTagValidator);

            if (Invalid)
                return new CommandResult(false, "Error on creating modbus tag", modbusTagValidator.Notifications);

            var modbusDevice = _plcRepository.FindByName(command.ModbusDevice);

            if (modbusDevice == null)
            {
                AddNotification("Plc", "Plc not found");
                return new CommandResult(false, "Error on creating modbus tag", Notifications);
            }

            modbusDevice.AddModbusTag(modbusTag);

            _plcRepository.CreateTags(modbusDevice);
            await _plcRepository.Commit();

            return new CommandResult(true, "Modbus tag successful created", modbusTag);
        }

        public async Task<ICommandResult> Handle(EditModbusTagCommand command)
        {
            // var modbusTag = new ModbusTag(command.Name, command.Address, command.Size);
            // var modbusTagValidator = new ModbusTagValidator(modbusTag);

            // AddNotifications(modbusTagValidator);

            var modbusTag = _modbusTagRepository.FindById(command.Id);

            // if (Invalid)
            //     return new CommandResult(false, "Error on creating modbus tag", modbusTagValidator.Notifications);

            _modbusTagRepository.Edit(modbusTag);
            await _modbusTagRepository.Commit();

            return new CommandResult(true, "Modbus tag successful created", modbusTag);
        }

        public async Task<ICommandResult> Handle(DeleteModbusTagCommand command)
        {
            var modbusTag = _modbusTagRepository.FindById(command.Id);

            if (modbusTag == null)
                return new CommandResult(false, "Error on deleting modbus tag", new { });

            _modbusTagRepository.Delete(modbusTag);
            await _modbusTagRepository.Commit();

            return new CommandResult(true, "Modbus tag successful deleted", modbusTag);
        }

        public async Task<ICommandResult> Handle(CreateMultipleModbusTagCommand command)
        {
            var modbusDevice = _plcRepository.FindByName(command.ModbusDevice);
            List<ModbusTag> modbusTags = new List<ModbusTag>();

            command.ModbusTags.ForEach(x => modbusTags.Add(
                new ModbusTag() {
                    Name = x.Name,
                    Deadband = x.Deadband,
                    DataType = x.DataType,
                    DataSize = x.DataSize,
                    Address = x.Address,
                    Scan = x.Scan
                }
            ));

            _modbusTagRepository.SaveMultiple(modbusTags);
            await _modbusTagRepository.Commit();

            return new CommandResult(true, "Modbus tags successful created", modbusTags);
        }
    }
}