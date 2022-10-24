using ZenoDcimManager.Domain.ZenoContext.Commands;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Domain.ZenoContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
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

        public async Task<ICommandResult> Handle(CreateRackEquipmentCommand command)
        {
            var baseEquipment = new BaseEquipment
            {
                Name = command.Name,
                Model = command.Model,
                Manufactor = command.Manufactor,
                SerialNumber = command.SerialNumber,
                Size = command.Size
            };
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

            var rack = await _rackRepository.FindByLocalization(command.RackLocalization);
            if (rack != null)
                rackEquipment.RackId = rack.Id;

            await _rackEquipmentRepository.Create(rackEquipment);
            await _rackEquipmentRepository.Commit();

            return new CommandResult(true, "Equipamento de rack criado com sucesso", rackEquipment);
        }
    }
}