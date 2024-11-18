using SkillUpHub.Notification.Models;

namespace SkillUpHub.Notification.Interfaces;

public interface IRabbitMqMessageHandler
{
    public Task SendToastAsync(Guid userId, string message, string method, NotificationType type);
    public Task SendEmailAsync(string sendTo, string subject, string message);
    public Task SendActionAsync(Guid userId, string message, string method, ActionType type);
}