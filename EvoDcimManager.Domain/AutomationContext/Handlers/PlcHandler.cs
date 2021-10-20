using EvoDcimManager.Domain.AutomationContext.Commands;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Domain.AutomationContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.AutomationContext.Handlers
{
    public class PlcHandler :
        Notifiable,
        ICommandHandler<PlcCommand>,
        ICommandHandler<EditPlcCommand>,
        ICommandHandler<DeletePlcCommand>
    {
        private readonly IPlcRepository _plcRepository;

        public PlcHandler(IPlcRepository plcRepository)
        {
            _plcRepository = plcRepository;
        }

        public ICommandResult Handle(PlcCommand command)
        {
            var plc = new Plc(
                command.Name,
                command.Manufactor,
                command.Model,
                command.IpAddress,
                command.NetworkMask,
                command.Gateway);

            var plcValidator = new PlcValidator(plc);

            AddNotifications(plcValidator);

            if (Invalid)
                return new CommandResult(false, "Error on creating Plc", plcValidator.Notifications);

            _plcRepository.Save(plc);
            return new CommandResult(false, "Plc successful created", plc);
        }

        public ICommandResult Handle(EditPlcCommand command)
        {
            var plc = _plcRepository.FindById(command.Id);
            plc.ChangeName(command.Name);
            plc.ChangeManufactor(command.Manufactor);
            plc.ChangeModel(command.Model);
            plc.ChangeIpAddress(command.IpAddress);
            plc.ChangeNetworkMask(command.NetworkMask);
            plc.ChangeGateway(command.Gateway);

            _plcRepository.Edit(plc);
            return new CommandResult(true, "Plc successful edited", plc);
        }

        public ICommandResult Handle(DeletePlcCommand command)
        {
            var plc = _plcRepository.FindById(command.Id);

            if (plc == null)
                return new CommandResult(false, "Error on deleting plc", new { });

            _plcRepository.Delete(plc);

            return new CommandResult(true, "Plc successful deleted", plc);
        }
    }
}