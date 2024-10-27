using System.ComponentModel.DataAnnotations;
using Hack24.Data.Models;

namespace Hack24.Data.Models;

public class Notification
{
    [Key]
    public int Id { get; set; }

    public string Message { get; set; }

    public bool IsRead { get; set; } = false;

    public string UserId { get; set; }
    public virtual User User { get; set; }
}