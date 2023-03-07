using ZenoDcimManager.Domain.ZenoContext.Commands;
using ZenoDcimManager.Domain.ZenoContext.Entities;
using ZenoDcimManager.Domain.ZenoContext.Repositories;
using ZenoDcimManager.Domain.ZenoContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.ActiveContext.Commands.Inputs;
using System;

namespace ZenoDcimManager.Domain.ZenoContext.Handlers
{
    public class RackHandler :
        Notifiable,
        ICommandHandler<CreateRackCommand>,
        ICommandHandler<RackEditorCommand>
    {
        private readonly IRackRepository _rackRepository;

        public RackHandler(IRackRepository rackRepository)
        {
            _rackRepository = rackRepository;
        }

        public async Task<ICommandResult> Handle(CreateRackCommand command)
        {
            var rack = new Rack(command.Size, command.Localization);
            rack.Name = command.Name;
            rack.Localization = command.Localization;
            rack.Size = command.Size;
            rack.Capacity = command.Capacity;
            rack.Power = command.Power;
            rack.Weight = command.Weight;
            rack.Description = command.Description;
            rack.SiteId = command.SiteId;
            rack.BuildingId = command.BuildingId;
            rack.FloorId = command.FloorId;
            rack.RoomId = command.RoomId;

            var rackValidator = new RackValidator(rack);

            AddNotifications(rackValidator);

            if (Invalid)
                return new CommandResult(false, "Error on create rack", Notifications);

            // save on repository
            await _rackRepository.CreateAsync(rack);
            await _rackRepository.Commit();

            return new CommandResult(true, "Rack was sucessful created", rack);
        }

        public async Task<ICommandResult> Handle(EditRackCommand command)
        {
            var rack = await _rackRepository.FindByIdAsync(command.Id);

            rack.Name = command.Name;
            rack.Localization = command.Localization;
            rack.Size = command.Size;
            rack.Capacity = command.Capacity;
            rack.Power = command.Power;
            rack.Weight = command.Weight;
            rack.Description = command.Description;
            rack.TrackModifiedDate();

            _rackRepository.Update(rack);
            await _rackRepository.Commit();

            return new CommandResult(true, "Rack was successful edited", rack);

        }

        public async Task<ICommandResult> Handle(RackEditorCommand command)
        {

            if (command.Id?.GetType() == typeof(Guid))
            {
                var rack = await _rackRepository.FindByIdAsync((Guid)command.Id);
                ConfigureObject(rack, command);
                rack.TrackModifiedDate();

                _rackRepository.Update(rack);
                await _rackRepository.Commit();

                return new CommandResult(true, "Rack alterado com sucesso", rack);
            }
            else
            {
                Rack rack = new Rack();
                ConfigureObject(rack, command);

                var rackValidator = new RackValidator(rack);

                AddNotifications(rackValidator);

                if (Invalid)
                    return new CommandResult(false, "Error on create rack", Notifications);

                // save on repository
                await _rackRepository.CreateAsync(rack);
                await _rackRepository.Commit();

                return new CommandResult(true, "Rack criado com sucesso", rack);

            }
        }

        private void ConfigureObject(Rack obj, RackEditorCommand command)
        {
            obj.Name = command.Name;
            obj.Localization = command.Localization;
            obj.Size = command.Size;
            obj.Capacity = command.Capacity;
            obj.Power = command.Power;
            obj.Weight = command.Weight;
            obj.Description = command.Description;
            obj.SiteId = command.SiteId;
            obj.BuildingId = command.BuildingId;
            obj.FloorId = command.FloorId;
            obj.RoomId = command.RoomId;
        }
    }
}