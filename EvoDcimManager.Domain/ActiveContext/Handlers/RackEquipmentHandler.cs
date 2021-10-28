using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.ActiveContext.Handlers
{
    public class RackEquipmentHandler :
        Notifiable,
        ICommandHandler<CreateRackEquipmentCommand>
    {
        private readonly IRackEquipmentRepository _rackEquipmentRepository;
        private readonly IRackRepository _rackRepository;

        public RackEquipmentHandler(IRackEquipmentRepository rackEquipmentRepository, IRackRepository rackRepository)
        {
            _rackEquipmentRepository = rackEquipmentRepository;
            _rackRepository = rackRepository;
        }

        public ICommandResult Handle(CreateRackEquipmentCommand command)
        {
            var baseEquipment = new BaseEquipment(
                    command.Name,
                    command.Model,
                    command.Manufactor,
                    command.SerialNumber);
            var baseEquipmentValidator = new BaseEquipmentValidator(baseEquipment);

            var rackEquipment = new RackEquipment(
                baseEquipment,
                command.InitialPosition,
                command.FinalPosition,
                command.RackEquipmentType);
            var rackEquipmentValidator = new RackEquipmentValidator(rackEquipment);

            AddNotifications(baseEquipmentValidator, rackEquipmentValidator);

            if (Invalid)
                return new CommandResult(false, "Error on creating rack equipment", Notifications);

            var rack = _rackRepository.FindByLocalization(command.RackLocalization);
            if (rack == null)
            {
                AddNotification("Rack", "Rack doesnt exists");
                return new CommandResult(false, "Error on creating rack equipment", Notifications);
            }

            rack.AddEquipment(rackEquipment);
            _rackRepository.AddRackEquipments(rack);

            return new CommandResult(true, "Rack equipment created successful", rackEquipment);
        }
    }
}