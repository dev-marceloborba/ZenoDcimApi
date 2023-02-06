using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Commands;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ActiveContext.Handlers
{
    public class EquipmentCardHandler : ICommandHandler<EquipmentCardSettingsEditorCommand>
    {
        private readonly IEquipmentCardSettingsRepository _repository;

        public EquipmentCardHandler(IEquipmentCardSettingsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(EquipmentCardSettingsEditorCommand command)
        {

            var equipmentCard = new EquipmentCardSettings
            {
                EquipmentId = command.EquipmentId,
                Parameter1 = command.Parameter1,
                Parameter2 = command.Parameter2,
                Parameter3 = command.Parameter3
            };

            await _repository.CreateAsync(equipmentCard);
            await _repository.Commit();

            return new CommandResult(true, "", null);
        }
    }
}