using Microsoft.AspNetCore.SignalR;

namespace SkillUpHub.Notification;

public class NotificationHub : Hub
{
    private Dictionary<Guid, string> users = new ();
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        
        var userId = Context.GetHttpContext()?.Request.Query["UserId"] ?? 
                     throw new NullReferenceException("Не удалось получить UserId");
        
        if(!string.IsNullOrEmpty(userId))
            users.Add(Guid.Parse(userId), Context.ConnectionId);
        
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        
        var userId = Context.GetHttpContext()?.Request.Query["UserId"] ?? 
                     throw new NullReferenceException("Не удалось получить UserId");
        
        if(!string.IsNullOrEmpty(userId))
            users.Remove(Guid.Parse(userId));
    }
}