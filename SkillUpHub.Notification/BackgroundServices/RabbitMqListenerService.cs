using Microsoft.Extensions.Options;
using SkillUpHub.Notification.Interfaces;
using SkillUpHub.Notification.Models;

namespace SkillUpHub.Notification.BackgroundServices;

public class RabbitMqListenerService(
    IMessageBusClient messageBusClient,
    IServiceProvider serviceProvider,
    IOptions<RabbitMqSettings> options) : BackgroundService
{
    private record ToastMessage(Guid UserId, string Message, string Method, NotificationType Type);
    private record EmailMessage(string SendTo, string Subject, string Message);
    private record ActionMessage(Guid UserId, string Message, string Method, ActionType Type);
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var scope = serviceProvider.CreateScope();
        var servicesHandler = scope.ServiceProvider.GetService<IRabbitMqMessageHandler>()!;
        
        var exchange = options.Value.Exchanges?.FirstOrDefault(x => x.Id == "notification") ?? 
                       throw new NullReferenceException("Не удалось найти обменники в appsettings.json");

        var toastQueue = exchange.Queues.FirstOrDefault(x => x.Id == "notification.toast") ?? 
                         throw new NullReferenceException("Очередь для уведомлений не найдена");
        messageBusClient.Subscribe(toastQueue.Name, async (ToastMessage message) => 
            await servicesHandler.SendToastAsync(message.UserId, message.Message, message.Method, message.Type));
        
        var emailQueue = exchange.Queues.FirstOrDefault(x => x.Id == "notification.email") ?? 
                         throw new NullReferenceException("Очередь для email уведомлений не найдена");
        messageBusClient.Subscribe(emailQueue.Name, async (EmailMessage message) => 
            await servicesHandler.SendEmailAsync(message.SendTo, message.Subject, message.Message));
        
        var actionQueue = exchange.Queues.FirstOrDefault(x => x.Id == "notification.action") ?? 
                          throw new NullReferenceException("Очередь для действий не найдена");
        messageBusClient.Subscribe(actionQueue.Name, async (ActionMessage message) => 
            await servicesHandler.SendActionAsync(message.UserId, message.Message, message.Method, message.Type));
        
        return Task.CompletedTask;
    }
}