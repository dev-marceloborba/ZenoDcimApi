using System.Threading.Tasks;
using Flunt.Notifications;
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

        public RoomHandler(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<ICommandResult> Handle(CreateRoomCommand command)
        {
            var room = new Room
            {
                Name = command.Name,
                FloorId = command.FloorId
            };

            await _roomRepository.CreateAsync(room);
            await _roomRepository.Commit();

            return new CommandResult(true, "Sala criada com sucesso", room);
        }
    }
}