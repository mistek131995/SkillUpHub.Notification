using Microsoft.AspNetCore.SignalR;
using SkillUpHub.Notification.Interfaces;
using SkillUpHub.Notification.Models;

namespace SkillUpHub.Notification.Handlers;

public class RabbitMqMessageHandler(IHubContext<NotificationHub> hubContext) : IRabbitMqMessageHandler
{
    public async Task SendToastAsync(Guid userId, string message, NotificationType type = NotificationType.Info)
    {
        var connectionId = NotificationHub.GetConnectionByUserId(userId);
        
        await hubContext.Clients.Client(connectionId).SendAsync("show-toast-notification", message, type);
    }

    public Task SendEmailAsync(string sendTo, string subject, string message)
    {
        throw new NotImplementedException();
    }
}