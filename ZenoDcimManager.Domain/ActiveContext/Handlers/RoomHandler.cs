using System.Threading.Tasks;
using Flunt.Notifications;
using ZenoDcimManager.Domain.ActiveContext.Repositories;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Commands.Inputs;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class RoomHandler : Notifiable,
        ICommandHandler<CreateRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomCardSettingsRepository _roomCardRepository;

        public RoomHandler(IRoomRepository roomRepository, IRoomCardSettingsRepository roomCardRepository)
        {
            _roomRepository = roomRepository;
            _roomCardRepository = roomCardRepository;
        }

        public async Task<ICommandResult> Handle(CreateRoomCommand command)
        {
            var room = new Room
            {
                Name = command.Name,
                RackCapacity = command.RackCapacity,
                PowerCapacity = command.PowerCapacity,
                FloorId = command.FloorId
            };

            await _roomRepository.CreateAsync(room);

            var cardSettings = new RoomCardSettings { RoomId = room.Id, Parameter1 = null, Parameter2 = null, Parameter3 = null };
            await _roomCardRepository.CreateAsync(cardSettings);

            await _roomRepository.Commit();

            return new CommandResult(true, "Sala criada com sucesso", room);
        }
    }
}