using ZenoDcimManager.Domain.ActiveContext.Commands;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ActiveContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace ZenoDcimManager.Domain.ActiveContext.Handlers
{
    public class RackHandler :
        Notifiable,
        ICommandHandler<CreateRackCommand>,
        ICommandHandler<EditRackCommand>
    {
        private readonly IRackRepository _rackRepository;

        public RackHandler(IRackRepository rackRepository)
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

            // save on repository
            _rackRepository.Save(rack);
            _rackRepository.Commit();

            return new CommandResult(true, "Rack was sucessful created", rack);
        }

        public ICommandResult Handle(EditRackCommand command)
        {
            var rack = _rackRepository.FindById(command.Id);
            rack.ChangeLocalization(command.Localization);
            rack.ChangeSize(command.Size);

            _rackRepository.Update(rack);
            _rackRepository.Commit();

            return new CommandResult(true, "Rack was successful edited", rack);

        }
    }
}