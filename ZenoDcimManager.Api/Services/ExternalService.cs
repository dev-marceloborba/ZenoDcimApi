namespace ZenoDcimManager.Api.Services
{
    public class ExternalService
    {
        private readonly IMqttClientService mqttClientService;
        public ExternalService(MqttClientServiceProvider provider)
        {
            mqttClientService = provider.MqttClientService;
        }
    }
}