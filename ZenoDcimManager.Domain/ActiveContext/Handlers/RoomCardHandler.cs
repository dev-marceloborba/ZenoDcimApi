using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ActiveContext.Handlers
{
    public class RoomCardHandler : ICommandHandler<RoomCardSettingsEditorCommand>
    {
        private readonly IRoomCardSettingsRepository _repository;

        public RoomCardHandler(IRoomCardSettingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(RoomCardSettingsEditorCommand command)
        {
            var card = new RoomCardSettings
            {
                RoomId = command.RoomId,
                Parameter1 = null,
                Parameter2 = null,
                Parameter3 = null
            };

            await _repository.CreateAsync(card);

            return new CommandResult(true, "", card);
        }
    }
}