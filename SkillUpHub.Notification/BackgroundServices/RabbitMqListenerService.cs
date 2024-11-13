using SkillUpHub.Notification.Interfaces;

namespace SkillUpHub.Notification.BackgroundServices;

public class RabbitMqListenerService(
    IMessageBusClient messageBusClient, 
    IServiceProvider serviceProvider) : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = serviceProvider.CreateScope();
        var servicesHandler = scope.ServiceProvider.GetService<IRabbitMqMessageHandler>()!;
        
        //messageBusClient.Subscribe("", async (Guid sessionId) => await servicesHandler.CreateAccountFailureAsync(sessionId));
        
        return Task.CompletedTask;
    }
}