using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Threading.Tasks;

namespace ZenoDcimManager.Domain.AutomationContext.Handlers
{
    public class PlcHandler :
        Notifiable,
        ICommandHandler<CreatePlcCommand>,
        ICommandHandler<EditPlcCommand>,
        ICommandHandler<DeletePlcCommand>
    {
        private readonly IPlcRepository _plcRepository;

        public PlcHandler(IPlcRepository plcRepository)
        {
            _plcRepository = plcRepository;
        }

        public async Task<ICommandResult> Handle(CreatePlcCommand command)
        {
            var plc = new Plc(
                command.Name,
                command.Manufactor,
                command.Model,
                command.IpAddress,
                command.TcpPort
                );

            var plcValidator = new PlcValidator(plc);

            AddNotifications(plcValidator);

            if (Invalid)
                return new CommandResult(false, "Error on creating Plc", plcValidator.Notifications);

            _plcRepository.Save(plc);
            await _plcRepository.Commit();

            return new CommandResult(true, "Plc successful created", plc);
        }

        public async Task<ICommandResult> Handle(EditPlcCommand command)
        {
            var plc = _plcRepository.FindById(command.Id);
            plc.ChangeName(command.Name);
            plc.ChangeManufactor(command.Manufactor);
            plc.ChangeModel(command.Model);
            plc.ChangeIpAddress(command.IpAddress);

            _plcRepository.Edit(plc);
            await _plcRepository.Commit();

            return new CommandResult(true, "Plc successful edited", plc);
        }

        public async Task<ICommandResult> Handle(DeletePlcCommand command)
        {
            var plc = _plcRepository.FindById(command.Id);

            if (plc == null)
                return new CommandResult(false, "Error on deleting plc", new { });

            _plcRepository.Delete(plc);
            await _plcRepository.Commit();

            return new CommandResult(true, "Plc successful deleted", plc);
        }
    }
}