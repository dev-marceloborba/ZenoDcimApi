using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.ActiveContext.Handlers
{
    public class CreateSwitchHandler : Notifiable, ICommandHandler<CreateSwitchCommand>
    {
        private readonly ISwitchRepository _switchRepository;

        public CreateSwitchHandler(ISwitchRepository switchRepository)
        {
            _switchRepository = switchRepository;
        }

        public ICommandResult Handle(CreateSwitchCommand command)
        {
            var equipment = new BaseEquipment(command.Name, command.Model, command.Manufactor, command.SerialNumber);
            var slot = new RackPosition(command.InitialPosition, command.FinalPosition);
            var sw = new Switch(equipment, command.EthPorts);

            AddNotifications(equipment, slot, sw);

            if (Invalid)
                return new CommandResult(false, "Error on creating switch", Notifications);

            _switchRepository.Save(sw);

            return new CommandResult(true, "Switch succesfull created", equipment);
        }
    }
}