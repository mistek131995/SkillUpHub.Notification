﻿using Microsoft.AspNetCore.SignalR;

namespace SkillUpHub.Notification;

public class NotificationHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        
        
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
        
        
    }
}