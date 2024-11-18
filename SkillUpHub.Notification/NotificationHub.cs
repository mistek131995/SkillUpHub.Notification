using System.Collections.Concurrent;
using Microsoft.AspNetCore.SignalR;

namespace SkillUpHub.Notification;

public class NotificationHub : Hub
{
    private static ConcurrentDictionary<Guid, string> users = new ();
    
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        
        var userId = Context.GetHttpContext()?.Request.Query["UserId"] ?? 
                     throw new NullReferenceException("Не удалось получить UserId");
        
        users.TryAdd(Guid.Parse(userId), Context.ConnectionId);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        
        var userId = Context.GetHttpContext()?.Request.Query["UserId"] ?? 
                     throw new NullReferenceException("Не удалось получить UserId");
        
        users.TryRemove(Guid.Parse(userId), out _);
    }

    public static string GetConnectionByUserId(Guid userId) => users[userId];
}