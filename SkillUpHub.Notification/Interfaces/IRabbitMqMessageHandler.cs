namespace SkillUpHub.Notification.Interfaces;

public interface IRabbitMqMessageHandler
{
    public Task SendToastAsync(Guid sessionId);
    public Task SendEmailAsync();
}