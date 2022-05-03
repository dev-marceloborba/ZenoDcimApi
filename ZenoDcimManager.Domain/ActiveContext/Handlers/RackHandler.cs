using ZenoDcimManager.Domain.ActiveContext.Commands;
using ZenoDcimManager.Domain.ActiveContext.Entities;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.ActiveContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Threading.Tasks;

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

        public async Task<ICommandResult> Handle(CreateRackCommand command)
        {
            var rack = new Rack(command.Size, command.Localization);
            var rackValidator = new RackValidator(rack);

            AddNotifications(rackValidator);

            if (Invalid)
                return new CommandResult(false, "Error on create rack", Notifications);

            // save on repository
            await _rackRepository.Save(rack);
            await _rackRepository.Commit();

            return new CommandResult(true, "Rack was sucessful created", rack);
        }

        public async Task<ICommandResult> Handle(EditRackCommand command)
        {
            var rack = await _rackRepository.FindById(command.Id);

            _rackRepository.Update(rack);
            await _rackRepository.Commit();

            return new CommandResult(true, "Rack was successful edited", rack);

        }
    }
}