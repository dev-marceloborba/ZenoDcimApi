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
            };
            var baseEquipmentValidator = new BaseEquipmentValidator(baseEquipment);

            var rackEquipment = new RackEquipment(
                baseEquipment,
                command.InitialPosition,
                command.FinalPosition,
                command.RackEquipmentType);

            rackEquipment.Client = command.Client;
            rackEquipment.Function = command.Function;
            rackEquipment.RackMountType = command.RackMountType;
            rackEquipment.RackEquipmentOrientation = command.RackEquipmentOrientation;
            rackEquipment.Occupation = command.Occupation;
            rackEquipment.Weight = command.Weight;
            rackEquipment.Power = command.Power;
            rackEquipment.Size = command.Size;
            rackEquipment.Status = command.Status;
            rackEquipment.Description = command.Description;

            var rackEquipmentValidator = new RackEquipmentValidator(rackEquipment);

            AddNotifications(baseEquipmentValidator, rackEquipmentValidator);

            if (Invalid)
                return new CommandResult(false, "Error on creating rack equipment", Notifications);

            var rack = await _rackRepository.FindByIdAsync(command.RackId);
            if (rack != null)
                rackEquipment.RackId = rack.Id;

            // Validações do equipamento com o rack

            if (rack.CheckBusyPosition(command.InitialPosition, command.Occupation))
                return new CommandResult(false, "Posição ocupada no rack", null);

            if (rackEquipment.Power > rack.GetAvailablePower())
                return new CommandResult(false, "Potência disponível do rack não suporta a instalação demandada", null);

            if (rackEquipment.Occupation > rack.TotalOccupedSlots())
                return new CommandResult(false, "Capacidade disponível do rack não suporta a instalação demanada", null);

            if (rackEquipment.Weight > rack.GetAvailableWeight())
                return new CommandResult(false, "Peso disponível do rack não suporta a instalação demandada", null);


            await _rackEquipmentRepository.Create(rackEquipment);
            await _rackEquipmentRepository.Commit();

            return new CommandResult(true, "Equipamento de rack criado com sucesso", rackEquipment);
        }
    }
}