using SkillUpHub.Notification.Models;

namespace SkillUpHub.Notification.Interfaces;

public interface IRabbitMqMessageHandler
{
    public Task SendToastAsync(Guid userId, string message, NotificationType notificationType);
    public Task SendEmailAsync(string sendTo, string subject, string message);
}