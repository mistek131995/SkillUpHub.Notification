namespace SkillUpHub.Notification.Interfaces;

public interface IRabbitMqMessageHandler
{
    public Task SendToastAsync(Guid userId, string title, string message);
    public Task SendEmailAsync(string sendTo, string subject, string message);
}