using Microsoft.AspNetCore.SignalR;
using SkillUpHub.Notification.Interfaces;

namespace SkillUpHub.Notification.Handlers;

public class RabbitMqMessageHandler(IHubContext<NotificationHub> hubContext) : IRabbitMqMessageHandler
{
    public async Task SendToastAsync(Guid userId, string title, string message)
    {
        var connectionId = NotificationHub.GetConnectionByUserId(userId);
        
        await hubContext.Clients.Client(connectionId).SendAsync("show-toast-notification", title, message);
    }

    public Task SendEmailAsync(string sendTo, string subject, string message)
    {
        throw new NotImplementedException();
    }
}