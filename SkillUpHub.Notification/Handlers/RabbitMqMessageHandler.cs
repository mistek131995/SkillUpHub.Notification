using SkillUpHub.Notification.Interfaces;

namespace SkillUpHub.Notification.Handlers;

public class RabbitMqMessageHandler : IRabbitMqMessageHandler
{
    public Task SendToastAsync(Guid sessionId)
    {
        throw new NotImplementedException();
    }

    public Task SendEmailAsync()
    {
        throw new NotImplementedException();
    }
}