﻿using SkillUpHub.Notification.Interfaces;

namespace SkillUpHub.Notification.BackgroundServices;

public class RabbitMqListenerService(
    IMessageBusClient messageBusClient, 
    IServiceProvider serviceProvider) : BackgroundService
{
    private record ToastMessage(Guid UserId, string Title, string Message);
    private record EmailMessage(string SendTo, string Subject, string Message);
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = serviceProvider.CreateScope();
        var servicesHandler = scope.ServiceProvider.GetService<IRabbitMqMessageHandler>()!;
        
        messageBusClient.Subscribe("notification.toast", async (ToastMessage message) => 
            await servicesHandler.SendToastAsync(message.UserId, message.Title, message.Message));
        messageBusClient.Subscribe("notification.email", async (EmailMessage message) => 
            await servicesHandler.SendEmailAsync(message.SendTo, message.Subject, message.Message));
        
        return Task.CompletedTask;
    }
}