using EvoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Validators
{
    public class ServerValidator : Notifiable
    {
        public ServerValidator(Server server)
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(server.Cpu, 5, "CPU", "CPU name needs a minimum of 5 characters")
                .IsGreaterThan(server.Memory, 0, "Memory", "Memory should be greater than zero")
                .IsGreaterThan(server.Storage, 0, "Storage", "Storage should be greater than zero")
            );
        }
    }
}