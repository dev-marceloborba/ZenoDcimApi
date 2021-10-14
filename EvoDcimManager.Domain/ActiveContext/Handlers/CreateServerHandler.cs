using System.Linq;
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
    public class CreateServerHandler : Notifiable, ICommandHandler<CreateServerCommand>
    {
        private readonly IServerRepository _serverRepository;
        private readonly IRackRepository _rackRepository;

        public CreateServerHandler(IServerRepository serverRepository, IRackRepository rackRepository)
        {
            _serverRepository = serverRepository;
            _rackRepository = rackRepository;
        }

        public ICommandResult Handle(CreateServerCommand command)
        {
            var equipment = new BaseEquipment(command.Name, command.Model, command.Manufactor, command.SerialNumber);

            var equipmentValidator = new BaseEquipmentValidator(equipment);

            var server = new Server(equipment,
                                  command.Cpu,
                                  command.Memory,
                                  command.Storage);

            var serverValidator = new ServerValidator(server);

            AddNotifications(equipmentValidator, serverValidator);

            if (Invalid)
                return new CommandResult(false, "Failure do create server", Notifications);

            var rack = _rackRepository.Find(command.RackId);
            if (rack == null)
            {
                AddNotification("Rack", "Rack was not found");
                return new CommandResult(false, "Rack was not found", "");
            }

            var slot = rack.Slots
                .FirstOrDefault(x =>
                    x.InitialPosition == command.InitialPosition
                );

            slot.AddEquipment(server);
            rack.PlaceEquipment(server, command.InitialPosition, command.FinalPosition);

            _serverRepository.Save(server);
            _rackRepository.UpdateRackSlots(rack.Slots);

            return new CommandResult(true, "Server succesfull created", server);
        }
    }
}