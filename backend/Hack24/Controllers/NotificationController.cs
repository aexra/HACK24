using Hack24.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hack24.Controllers;

[ApiController]
[Route("api/notifications")]
public class NotificationController : ControllerBase
{
    [HttpPost("notify")]
    [Authorize(Roles = "Admin")]
    private void SendMessage(string message)
    {
        // Получаем контекст хаба
        var context = Microsoft.AspNet.SignalR.GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        // Отправляем сообщение
        context.Clients.All.displayMessage(message);
    }
}
