using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace ZenoDcimManager.Api.Hubs
{
    public class AlarmHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // await Clients.All.SendAsync("ReceiveMessage", user, message);
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        // public void PersistData(string serializedData)
        // {
        //     var normalizedData = JsonConvert.DeserializeObject(serializedData);

        // }
    }
}