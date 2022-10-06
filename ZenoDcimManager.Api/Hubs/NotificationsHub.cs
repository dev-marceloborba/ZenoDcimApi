using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using ZenoDcimManager.Domain.AutomationContext.Entities;
using ZenoDcimManager.Domain.AutomationContext.Hubs;

namespace ZenoDcimManager.Api.Hubs
{
    public class NotificationsHub : Hub<INotificationClient>
    {
        public async Task SendAlarmNotification(Alarm alarm)
        {
            await Clients.All.SendAlarmNotification(alarm);
            // await Clients.All.SendAsync("alarm-notification", "New alarm");
        }

        public override Task OnConnectedAsync()
        {
            Console.WriteLine("User connected");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("User disconnected");
            return base.OnDisconnectedAsync(exception);
        }
    }
}