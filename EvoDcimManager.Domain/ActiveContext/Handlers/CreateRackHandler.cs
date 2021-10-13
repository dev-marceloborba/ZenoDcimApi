using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.Validators;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.ActiveContext.Handlers
{
    public class CreateRackHandler : Notifiable, ICommandHandler<CreateRackCommand>
    {
        private readonly IRackRepository _rackRepository;

        public CreateRackHandler(IRackRepository rackRepository)
        {
            _rackRepository = rackRepository;
        }

        public ICommandResult Handle(CreateRackCommand command)
        {
            var rack = new Rack(command.Size, command.Localization);
            var rackValidator = new RackValidator(rack);

            AddNotifications(rackValidator);

            if (Invalid)
                return new CommandResult(false, "Error on create rack", Notifications);

            rack.InitEmptyRack();

            // save on repository
            _rackRepository.Save(rack);

            return new CommandResult(true, "Rack was sucessful created", rack);
        }
    }
}