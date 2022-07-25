using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class FloorHandler : Notifiable,
        ICommandHandler<CreateFloorCommand>
    {
        private readonly IFloorRepository _floorRepository;

        public FloorHandler(IFloorRepository floorRepository)
        {
            _floorRepository = floorRepository;
        }

        public async Task<ICommandResult> Handle(CreateFloorCommand command)
        {
            var floor = new Floor
            {
                Name = command.Name,
                BuildingId = command.BuildingId,
            };

            await _floorRepository.CreateAsync(floor);
            await _floorRepository.Commit();

            return new CommandResult(true, "Andar criado com sucesso", floor);
        }
    }
}