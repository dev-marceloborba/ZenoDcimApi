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
    public class StorageHandler : Notifiable, ICommandHandler<CreateStorageCommand>
    {
        private readonly IStorageRepository _storageRepository;
        private readonly IRackRepository _rackRepository;

        public StorageHandler(IStorageRepository storageRepository, IRackRepository rackRepository)
        {
            _storageRepository = storageRepository;
            _rackRepository = rackRepository;
        }

        public ICommandResult Handle(CreateStorageCommand command)
        {
            var equipment = new BaseEquipment(command.Name, command.Model, command.Manufactor, command.SerialNumber);
            var equipmentValidator = new BaseEquipmentValidator(equipment);

            var storage = new Storage(equipment, command.InitialPosition, command.FinalPosition, command.Capacity);
            var storageValidator = new StorageValidator(storage);

            AddNotifications(equipmentValidator, storageValidator);

            if (Invalid)
                return new CommandResult(false, "Cannot create storage", Notifications);

            var rack = _rackRepository.FindByLocalization(command.RackLocalization);
            if (rack == null)
            {
                AddNotification("Rack", "Rack was not found");
                return new CommandResult(false, "Rack was not found", "");
            }
            storage.AssociateRackId(rack.Id);
            _storageRepository.Save(storage);

            return new CommandResult(true, "Storage succesful created", storage);

        }
    }
}