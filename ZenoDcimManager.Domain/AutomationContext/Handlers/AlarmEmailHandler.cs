using System.Threading.Tasks;
using ZenoDcimManager.Domain.UserContext.Repositories;
using ZenoDcimManager.Shared.Services;

namespace ZenoDcimManager.Domain.AutomationContext.Handlers
{
    public class AlarmEmailHandler
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public AlarmEmailHandler(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task Handle(string alarmMessage)
        {
            var users = await _userRepository.FindAllAsync();
            foreach (var user in users)
            {
                if (user.Group.ReceiveEmail == true)
                {
                    var to = user.FirstName;
                    var email = user.Email;
                    _emailService.Send(to, email, "Zeno DCIM", alarmMessage);
                }
            }
        }
    }
}