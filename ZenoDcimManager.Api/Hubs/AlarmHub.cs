using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ZenoDcimManager.Api.Hubs
{
    public class AlarmHub : Hub
    {
        public Task SendMessage(string user, string message)
        {
            return Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public void PersistData(string serializedData)
        {
            var normalizedData = JsonConvert.DeserializeObject(serializedData);

        }
    }
}