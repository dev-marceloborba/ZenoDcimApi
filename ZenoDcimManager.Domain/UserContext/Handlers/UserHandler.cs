using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Entities;
using ZenoDcimManager.Domain.UserContext.Enums;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.Services;
using ZenoDcimManager.Domain.UserContext.Validators;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using ZenoDcimManager.Shared.Services;
using Flunt.Notifications;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.ValueObjects;
using System;
using Microsoft.Extensions.Options;
using Microsoft.Win32;

namespace ZenoDcimManager.Domain.UserContext.Handlers
{
    public class UserHandler :
        Notifiable,
        ICommandHandler<CreateUserCommand>,
        ICommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IEmailService _emailService;
        private readonly ICryptoService _cryptoService;

        public UserHandler(IUserRepository userRepository, IGroupRepository groupRepository, IEmailService emailService, ICryptoService cryptoService, ICompanyRepository companyRepository)
        {
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _emailService = emailService;
            _cryptoService = cryptoService;
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult> Handle(CreateUserCommand command)
        {
            // Fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Nao foi possivel criar o usuario", command.Notifications);
            }

            // verifica se o usuário já existe na base
            var exists = await _userRepository.CheckIfExists(command.Email);
            if (exists)
            {
                return new CommandResult(false, "Usuário já existente no sistema", "");
            }

            var hashedPassword = _cryptoService.EncryptPassword(command.Password);

            var user = new User
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Email = command.Email,
                HashedPassword = hashedPassword,
                Active = true
            };
            user.CompanyId = command.CompanyId;
            user.GroupId = command.GroupId;

            var userValidator = new UserValidator(user);

            // Grouping notifications
            AddNotifications(userValidator);

            if (Invalid)
                return new CommandResult(false, "Nao foi possivel criar o usuario", Notifications);

            // save informations
            await _userRepository.CreateAsync(user);
            await _userRepository.Commit();

            // send e-mail
            _emailService.Send(user.ToString(), user.Email, "Welcome to Zeno DCIM", "Your account was created");

            return new CommandResult(true, "Usuario criado com sucesso", new UserOutputCommand(user.Id, user.FirstName, user.LastName, user.Email, user.Active, null, null));

        }

        public async Task<ICommandResult> Handle(EditUserCommand command)
        {
            // command.Validate();
            // if (command.Invalid)
            // {
            //     AddNotifications(command);
            //     return new CommandResult(false, "Nao foi possivel editar o usuario", Notifications);
            // }

            var user = await _userRepository.FindByIdAsync(command.Id);
            var group = await _groupRepository.FindByIdAsync(command.GroupId);

            if (user == null)
            {
                AddNotification("User", "User not found");
                return new CommandResult(false, "Nao foi possivel editar o usuario", Notifications);
            }

            user.FirstName = command.FirstName;
            user.LastName = command.LastName;
            user.Email = command.Email;
            user.Active = command.Active;
            user.GroupId = group.Id;

            _userRepository.Update(user);

            await _userRepository.Commit();

            var outputGroup = new UserGroupOutputCommand {
                Id = group.Id,
                Name = group.Name,
                Description = group.Description,
                Actions = new ActionPermissions
                {
                    AckAlarms = group.ActionAckAlarms,
                    EditConnections = group.ActionEditConnections
                },
                Registers = new RegisterPermissions
                {
                    Alarms = group.RegisterAlarms,
                    Datacenter = group.RegisterDatacenter,
                    Parameters = group.RegisterParameters,
                    Users = group.RegisterUsers,
                    Notifications = group.RegisterNotifications
                },
                Views = new ViewPermissions
                {
                    Alarms = group.ViewAlarms,
                    Equipments = group.ViewEquipments,
                    Parameters = group.ViewParameters
                },
                General = new GeneralPermissions
                {
                    ReceiveEmail = group.ReceiveEmail
                }
            
            };

            return new CommandResult(true, "Usuario alterado com sucesso", new UserOutputCommand(
                user.Id, user.FirstName, user.LastName, user.Email, user.Active, null, outputGroup
            ));
        }
    }
}