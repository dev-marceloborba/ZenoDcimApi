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

namespace ZenoDcimManager.Domain.UserContext.Handlers
{
    public class UserHandler :
        Notifiable,
        ICommandHandler<CreateUserCommand>,
        ICommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly ICryptoService _cryptoService;

        public UserHandler(IUserRepository userRepository, IEmailService emailService, ICryptoService cryptoService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _cryptoService = cryptoService;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            // Fail fast validations
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Nao foi possivel criar o usuario", command.Notifications);
            }

            var role = (EUserRole)command.Role;
            var hashedPassword = _cryptoService.EncryptPassword(command.Password);
            var user = new User(command.FirstName, command.LastName, command.Email, hashedPassword, role);

            var userValidator = new UserValidator(user);

            // Grouping notifications
            AddNotifications(userValidator);

            if (Invalid)
                return new CommandResult(false, "Nao foi possivel criar o usuario", "");

            // save informations
            _userRepository.Save(user);

            // send e-mail
            _emailService.Send(user.ToString(), user.Email, "Welcome to Zeno DCIM", "Your account was created");

            return new CommandResult(true, "Usuario criado com sucesso", user);

        }

        public ICommandResult Handle(EditUserCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Nao foi possivel editar o usuario", command.Notifications);
            }

            var user = _userRepository.FindUserByEmail(command.Email);

            var role = (EUserRole)command.Role;
            var editedUser = new User(command.FirstName, command.LastName, command.Email, role);

            user.CopyWith(editedUser);

            _userRepository.Update(user);

            return new CommandResult(true, "Usuario alterado com sucesso", user);
        }
    }
}