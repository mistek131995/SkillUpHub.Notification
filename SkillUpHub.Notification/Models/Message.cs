namespace SkillUpHub.Notification.Models;

public class Message
{
    public Guid? UserId { get; set; }
    public Guid? SessionId { get; set; }
    
    public string Text { get; set; } = string.Empty;
}