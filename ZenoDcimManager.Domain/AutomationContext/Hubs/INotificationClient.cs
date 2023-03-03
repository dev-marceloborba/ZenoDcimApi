using System.Threading.Tasks;
using ZenoDcimManager.Domain.AutomationContext.Entities;

namespace ZenoDcimManager.Domain.AutomationContext.Hubs
{
    public interface INotificationClient
    {
        Task SendAlarmNotification(Alarm alarm);
        Task SendNotification(string key, object data);
    }
}