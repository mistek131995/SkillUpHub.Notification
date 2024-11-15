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
        
        messageBusClient.Subscribe("notification.toast", async (Guid sessionId) => 
            await servicesHandler.SendToastAsync(sessionId));
        messageBusClient.Subscribe("notification.email", async ((string sendTo, string subject, string message) message) => 
            await servicesHandler.SendEmailAsync(message.sendTo, message.subject, message.message));
        
        return Task.CompletedTask;
    }
}