using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
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
            var cpu = new Cpu(command.Cpu);
            var memory = new Memory(command.Memory);
            var storage = new Capacity(command.Storage);
            var occupation = new Capacity(command.Occupation);
            var equipment = new BaseEquipment(command.Name, command.Model, command.Manufactor, command.SerialNumber);

            var server = new Server(equipment,
                                  occupation,
                                  cpu,
                                  memory,
                                  storage);

            AddNotifications(cpu, memory, storage, occupation, equipment, server);

            if (Invalid)
                return new CommandResult(false, "Failure do create server", Notifications);

            var rack = _rackRepository.Find(command.RackId);
            if (rack == null)
            {
                AddNotification("Rack", "Rack was not found");
                return new CommandResult(false, "Rack was not found", "");
            }

            server.AssociateRack(rack);

            _serverRepository.Save(server);

            return new CommandResult(true, "Server succesfull created", server);
        }
    }
}