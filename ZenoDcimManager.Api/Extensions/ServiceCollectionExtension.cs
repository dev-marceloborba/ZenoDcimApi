using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MQTTnet.Client;
using ZenoDcimManager.Api.Services;
using ZenoDcimManager.Api.Settings;

namespace ZenoDcimManager.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMqttClientHostedService(this IServiceCollection services)
        {
            services.AddMqttClientServiceWithConfig(aspOptionBuilder =>
            {
                var clientSettinigs = AppSettingsProvider.ClientSettings;
                var brokerHostSettings = AppSettingsProvider.BrokerHostSettings;

                aspOptionBuilder
                    .WithCredentials(clientSettinigs.UserName, clientSettinigs.Password)
                    .WithClientId(clientSettinigs.Id)
                    .WithCleanSession(true)
                    .WithProtocolVersion(MQTTnet.Formatter.MqttProtocolVersion.V311)
                    .WithTimeout(TimeSpan.FromSeconds(1000 * 2))
                    // .WithTcpServer(brokerHostSettings.Host, brokerHostSettings.Port);
                    .WithWebSocketServer("wss://zenobroker.eastus.cloudapp.azure.com:8091");
            });
            return services;
        }

        private static IServiceCollection AddMqttClientServiceWithConfig(this IServiceCollection services, Action<MqttClientOptionsBuilder> configure)
        {
            services.AddSingleton<MqttClientOptions>(serviceProvider =>
            {
                var optionBuilder = new MqttClientOptionsBuilder();
                configure(optionBuilder);
                return optionBuilder.Build();
            });
            services.AddSingleton<MqttClientService>();
            services.AddSingleton<IHostedService>(serviceProvider =>
            {
                return serviceProvider.GetService<MqttClientService>();
            });
            services.AddSingleton<MqttClientServiceProvider>(serviceProvider =>
            {
                var mqttClientService = serviceProvider.GetService<MqttClientService>();
                var mqttClientServiceProvider = new MqttClientServiceProvider(mqttClientService);
                return mqttClientServiceProvider;
            });
            return services;
        }
    }
}