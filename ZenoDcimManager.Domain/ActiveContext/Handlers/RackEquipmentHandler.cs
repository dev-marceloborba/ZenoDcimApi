using ZenoDcimManager.Domain.ActiveContext.Commands;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ActiveContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace ZenoDcimManager.Domain.ActiveContext.Handlers
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
            _rackEquipmentRepository.Commit();

            return new CommandResult(true, "Rack equipment created successful", rackEquipment);
        }
    }
}