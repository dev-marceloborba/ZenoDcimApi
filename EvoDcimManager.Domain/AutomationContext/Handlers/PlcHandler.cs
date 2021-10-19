using EvoDcimManager.Domain.AutomationContext.Commands;
using EvoDcimManager.Domain.AutomationContext.Entities;
using EvoDcimManager.Domain.AutomationContext.Repositories;
using EvoDcimManager.Domain.AutomationContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.AutomationContext.Handlers
{
    public class PlcHandler : Notifiable, ICommandHandler<PlcCommand>
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
    }
}