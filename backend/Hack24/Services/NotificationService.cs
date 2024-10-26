using Hack24.Data.Models;
using Hack24.Hubs;
using Microsoft.AspNetCore.SignalR;
using Web.Data.Contexts;

namespace Hack24.Services;

public class NotificationService
{
    private readonly IdentityContext _context;
    private readonly IHubContext<NotificationHub> _hubContext;

    public NotificationService(IdentityContext context, IHubContext<NotificationHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;
    }

    public async Task SendNotificationAsync(string userId, string message)
    {
        // Сохранение уведомления в базе данных
        var notification = new Notification
        {
            UserId = userId,
            Message = message,
            IsRead = false
        };

        _context.Notifications.Add(notification);
        await _context.SaveChangesAsync();

        // Отправка уведомления через SignalR
        await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", message);
    }
}