using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.Validators;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.ActiveContext.Handlers
{
    public class CreateSwitchHandler : Notifiable, ICommandHandler<CreateSwitchCommand>
    {
        private readonly ISwitchRepository _switchRepository;
        private readonly IRackRepository _rackRepository;

        public CreateSwitchHandler(ISwitchRepository switchRepository, IRackRepository rackRepository)
        {
            _switchRepository = switchRepository;
            _rackRepository = rackRepository;
        }

        public ICommandResult Handle(CreateSwitchCommand command)
        {
            var equipment = new BaseEquipment(command.Name, command.Model, command.Manufactor, command.SerialNumber);
            var equipmentValidator = new BaseEquipmentValidator(equipment);


            var sw = new Switch(equipment, command.InitialPosition, command.FinalPosition, command.EthPorts);
            var swValidator = new SwitchValidator(sw);

            AddNotifications(equipmentValidator, swValidator);

            if (Invalid)
                return new CommandResult(false, "Error on creating switch", Notifications);

            var rack = _rackRepository.FindByLocalization(command.RackLocalization);
            if (rack == null)
            {
                AddNotification("Rack", "Rack was not found");
                return new CommandResult(false, "Rack was not found", "");
            }

            sw.AssociateRackId(rack.Id);
            _switchRepository.Save(sw);

            return new CommandResult(true, "Switch succesfull created", equipment);
        }
    }
}