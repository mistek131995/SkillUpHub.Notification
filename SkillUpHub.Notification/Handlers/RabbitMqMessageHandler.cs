using Microsoft.AspNetCore.SignalR;
using SkillUpHub.Notification.Interfaces;

namespace SkillUpHub.Notification.Handlers;

public class RabbitMqMessageHandler(IHubContext<NotificationHub> hubContext) : IRabbitMqMessageHandler
{
    public async Task SendToastAsync(Guid userId, string title, string message)
    {
        await hubContext.Clients.User(userId.ToString()).SendAsync("", new
        {
            Title = title,
            Message = message
        });
    }

    public Task SendEmailAsync(string sendTo, string subject, string message)
    {
        throw new NotImplementedException();
    }
}