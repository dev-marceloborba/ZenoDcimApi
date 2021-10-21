using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace EvoDcimManager.Api.Hubs
{
    public class AlarmHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}