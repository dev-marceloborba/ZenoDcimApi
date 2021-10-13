using EvoDcimManager.Domain.ActiveContext.Entities;
using Flunt.Notifications;
using Flunt.Validations;

namespace EvoDcimManager.Domain.ActiveContext.Validators
{
    public class SwitchValidator : Notifiable
    {
        public SwitchValidator(Switch sw)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(sw.EthPorts, 0, "EthPorts", "EthPorts should be greater than zero")
            );
        }
    }
}