namespace SkillUpHub.Notification.Interfaces;

public interface IRabbitMqMessageHandler
{
    public Task CreateAccountFailureAsync(Guid sessionId);
}