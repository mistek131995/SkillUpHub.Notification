using SkillUpHub.Notification.Interfaces;

namespace SkillUpHub.Notification.Handlers;

public class RabbitMqMessageHandler : IRabbitMqMessageHandler
{
    public Task CreateAccountFailureAsync(Guid sessionId)
    {
        throw new NotImplementedException();
    }
}