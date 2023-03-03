using ZenoDcimManager.Domain.UserContext.Commands;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Domain.UserContext.Services;
using ZenoDcimManager.Shared.Commands;
using ZenoDcimManager.Shared.Handlers;
using Flunt.Notifications;
using ZenoDcimManager.Domain.UserContext.Commands.Output;
using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.ValueObjects;

namespace ZenoDcimManager.Domain.UserContext.Handlers
{
    public class LoginHandler : Notifiable, ICommandHandler<LoginCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptoService _cryptoService;
        private readonly ITokenService _tokenService;

        public LoginHandler(IUserRepository userRepository, ICryptoService cryptoService, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _cryptoService = cryptoService;
            _tokenService = tokenService;
        }

        public async Task<ICommandResult> Handle(LoginCommand command)
        {
            command.Validate();
            if (command.Invalid)
                return new CommandResult(false, "Error on login", command.Notifications);

            var user = await _userRepository.FindUserByEmail(command.Email);

            if (user == null)
            {
                AddNotification("E-mail", "E-mail doesn't exists");
                return new CommandResult(false, "Error on login", Notifications);
            }

            var isAuthenticated = _cryptoService.ValidatePassword(command.Password, user.HashedPassword);

            if (isAuthenticated)
            {
                AddNotification("Password", "Invalid password");
                return new CommandResult(false, "Error on login", Notifications);
            }

            var token = _tokenService.GenerateToken(user);

            var permissions = new UserGroupOutputCommand
            {
                Id = user.Group.Id,
                Name = user.Group.Name,
                Description = user.Group.Description,
                Actions = new ActionPermissions
                {
                    AckAlarms = user.Group.ActionAckAlarms,
                    EditConnections = user.Group.ActionEditConnections
                },
                Registers = new RegisterPermissions
                {
                    Alarms = user.Group.RegisterAlarms,
                    Datacenter = user.Group.RegisterDatacenter,
                    Parameters = user.Group.RegisterParameters,
                    Users = user.Group.RegisterUsers,
                    Notifications = user.Group.RegisterNotifications
                },
                Views = new ViewPermissions
                {
                    Alarms = user.Group.ViewAlarms,
                    Equipments = user.Group.ViewEquipments,
                    Parameters = user.Group.ViewParameters
                },
                General = new GeneralPermissions
                {
                    ReceiveEmail = user.Group.ReceiveEmail
                }

            };

            return new CommandResult(true, "Logado com sucesso", new AuthenticationOutputCommand(token, user.FirstName, user.Email, user.Id, permissions));
        }
    }
}