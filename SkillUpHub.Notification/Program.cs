using SkillUpHub.Notification;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

var app = builder.Build();

app.UseRouting();
app.MapHub<NotificationHub>("/notificationHub");

app.Run();