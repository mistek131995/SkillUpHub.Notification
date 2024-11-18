using Microsoft.AspNetCore.SignalR;
using SkillUpHub.Notification.Interfaces;
using SkillUpHub.Notification.Models;

namespace SkillUpHub.Notification.Handlers;

public class RabbitMqMessageHandler(IHubContext<NotificationHub> hubContext) : IRabbitMqMessageHandler
{
    public async Task SendToastAsync(Guid userId, string message, string method, NotificationType type = NotificationType.Info)
    {
        var connectionId = NotificationHub.GetConnectionByUserId(userId);
        
        await hubContext.Clients.Client(connectionId).SendAsync(method, message, type);
    }

    public Task SendEmailAsync(string sendTo, string subject, string message)
    {
        throw new NotImplementedException();
    }

    public async Task SendActionAsync(Guid userId, string message, string method, ActionType type)
    {
        var connectionId = NotificationHub.GetConnectionByUserId(userId);
        
        await hubContext.Clients.Client(connectionId).SendAsync(method, message, type);
    }
}