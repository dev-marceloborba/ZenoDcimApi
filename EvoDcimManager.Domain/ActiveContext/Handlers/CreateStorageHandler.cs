using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.ValueObjects;
using EvoDcimManager.Shared.Commands;
using EvoDcimManager.Shared.Handlers;
using Flunt.Notifications;

namespace EvoDcimManager.Domain.ActiveContext.Handlers
{
    public class CreateStorageHandler : Notifiable, ICommandHandler<CreateStorageCommand>
    {
        private readonly IStorageRepository _storageRepository;

        public CreateStorageHandler(IStorageRepository storageRepository)
        {
            _storageRepository = storageRepository;
        }

        public ICommandResult Handle(CreateStorageCommand command)
        {

            var capacity = new Capacity(command.Capacity);
            var equipment = new BaseEquipment(command.Name, command.Model, command.Manufactor, command.SerialNumber);
            var occupation = new Capacity(command.Capacity);
            var storage = new Storage(equipment, occupation, capacity);

            AddNotifications(capacity, equipment, occupation, storage);

            if (Invalid)
                return new CommandResult(false, "Cannot create storage", Notifications);

            _storageRepository.Save(storage);

            return new CommandResult(true, "Storage succesful created", storage);

        }
    }
}