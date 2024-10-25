using Hack24.Hubs;
using Hack24.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Web.Data.Contexts;

namespace Hack24.Controllers;

[ApiController]
[Route("api/notifications")]
public class NotificationController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly NotificationService _notificationService;

    public NotificationController(DataContext context, IHubContext<NotificationHub> hubContext, NotificationService notificationService)
    {
        _context = context;
        _hubContext = hubContext;
        _notificationService = notificationService;
    }

    [HttpPost("notify/{userId}&{message}")]
    public async Task<IActionResult> NotifyUser([FromRoute] string userId, [FromRoute] string message)
    {
        await _notificationService.SendNotificationAsync(userId, message);
        return Ok();
    }

    [HttpGet("get/{userId}")]
    public async Task<IActionResult> GetUserNotifications([FromRoute] string userId)
    {
        var notifications = await _context.Notifications
            .Where(n => n.UserId == userId)
            .ToListAsync();
        return Ok(notifications);
    }

    [HttpPost("mark/{notificationId}")]
    public async Task<IActionResult> MarkAsRead([FromRoute] int notificationId)
    {
        var notification = await _context.Notifications.FindAsync(notificationId);
        if (notification == null)
        {
            return NotFound();
        }

        notification.IsRead = true;
        await _context.SaveChangesAsync();
        return Ok();
    }
}
