using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Hubs;

namespace ZenoDcimManager.Api.Hubs
{
    public class NotificationsHub : Hub<INotificationClient>
    {
        private readonly ILogger<NotificationsHub> _logger;

        public NotificationsHub(ILogger<NotificationsHub> logger)
        {
            _logger = logger;
            _logger.LogInformation("Notification Hub has started!");
        }

        public async Task SendAlarmNotification(Alarm alarm)
        {
            await Clients.All.SendAlarmNotification(alarm);
            // await Clients.All.SendAsync("alarm-notification", "New alarm");
        }

        public async Task SendNotification(string key, object data)
        {
            var message = "";
            if (data.GetType() == typeof(string))
            {
                message = (string)data;
            }
            else
            {
                message = JsonConvert.SerializeObject(data);
            }

            await Clients.All.SendNotification(key, message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}