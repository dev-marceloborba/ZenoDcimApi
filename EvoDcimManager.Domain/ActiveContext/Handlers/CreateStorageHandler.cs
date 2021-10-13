using EvoDcimManager.Domain.ActiveContext.Commands;
using EvoDcimManager.Domain.ActiveContext.Entities;
using EvoDcimManager.Domain.ActiveContext.Repositories;
using EvoDcimManager.Domain.ActiveContext.Validators;
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
            var equipment = new BaseEquipment(command.Name, command.Model, command.Manufactor, command.SerialNumber);
            var equipmentValidator = new BaseEquipmentValidator(equipment);

            var slot = new RackPosition(command.InitialPosition, command.FinalPosition);
            var rackPositionValidator = new RackPositionValidator(slot);

            var storage = new Storage(equipment, command.Capacity);
            var storageValidator = new StorageValidator(storage);

            AddNotifications(equipmentValidator, rackPositionValidator, storageValidator);

            if (Invalid)
                return new CommandResult(false, "Cannot create storage", Notifications);

            _storageRepository.Save(storage);

            return new CommandResult(true, "Storage succesful created", storage);

        }
    }
}