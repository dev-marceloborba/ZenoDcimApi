using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;
using ZenoDcimManager.Api.Hubs;
using ZenoDcimManager.Domain.AutomationContext.Hubs;

namespace ZenoDcimManager.Api.Services
{
    public class MqttClientService : IMqttClientService
    {
        private readonly IMqttClient _mqttClient;
        private readonly MqttClientOptions _options;
        private readonly IHubContext<NotificationsHub, INotificationClient> _hubContext;
        private readonly ILogger<MqttClientService> _logger;

        public MqttClientService(MqttClientOptions options, IHubContext<NotificationsHub, INotificationClient> hubContext, ILogger<MqttClientService> logger)
        {
            _hubContext = hubContext;
            _options = options;
            _mqttClient = new MqttFactory().CreateMqttClient();
            _logger = logger;
            ConfigureMqttClient();
        }

        private void ConfigureMqttClient()
        {
            _mqttClient.ConnectedAsync += HandleConnectedAsync;
            _mqttClient.DisconnectedAsync += HandleDisconnectedAsync;
            _mqttClient.ApplicationMessageReceivedAsync += HandleApplicationMessageReceivedAsync;
        }

        public async Task HandleConnectedAsync(MqttClientConnectedEventArgs eventArgs)
        {
            _logger.LogInformation("MQTT client connected");
            await _mqttClient.SubscribeAsync("/runtime");
        }

        public async Task HandleDisconnectedAsync(MqttClientDisconnectedEventArgs eventArgs)
        {
            _logger.LogInformation("MQTT client disconnected");
            await Task.CompletedTask;
        }

        public async Task HandleApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs e)
        {
            _logger.LogInformation("### RECEIVED APPLICATION MESSAGE ###");
            var message = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            // await hubContext.Clients.All.SendAsync("Runtime", message);
            // _logger.LogInformation(message);
            await _hubContext.Clients.All.SendNotification("runtime", message);
            _logger.LogInformation("Message sended to SignalR hub");
            // _logger.LogInformation($"+ Topic = {e.ApplicationMessage.Topic}");
            // _logger.LogInformation($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
            // _logger.LogInformation($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
            // _logger.LogInformation($"+ Retain = {e.ApplicationMessage.Retain}");

            // await Task.CompletedTask;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _mqttClient.ConnectAsync(_options);

            _ = Task.Run(
                async () =>
                {
                    while (true)
                    {
                        try
                        {
                            if (!await _mqttClient.TryPingAsync())
                            {
                                await _mqttClient.ConnectAsync(_mqttClient.Options, CancellationToken.None);
                                _logger.LogInformation("The MQTT Client is connected");
                            }
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "The MQTT client connection failed");
                        }
                        finally
                        {
                            await Task.Delay(TimeSpan.FromSeconds(5));
                        }
                    }
                }
            );
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                var disconnectedOption = new MqttClientDisconnectOptions
                {
                    Reason = MqttClientDisconnectReason.NormalDisconnection,
                    ReasonString = "NormalDisconnection"
                };
                await _mqttClient.DisconnectAsync(disconnectedOption, cancellationToken);
            }
            await _mqttClient.DisconnectAsync();
        }
    }
}