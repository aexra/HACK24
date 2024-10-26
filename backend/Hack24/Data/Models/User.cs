using Hack24.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace Web.Data.Models;

public class User : IdentityUser
{
    public byte[]? Image { get; set; }
    public string? Bio {  get; set; }
    public string? Hobby { get; set; }
    public string? Pets { get; set; }
    public string? FamilyInviteKey { get; set; }
    public string? Telegram { get; set; }
    public string? VK { get; set; }

    public new string? Email = null;

    public int? PostId { get; set; } = 6;
    public virtual Post Post { get; set; }

    public virtual ICollection<Notification> Notifications { get; set; }
    public virtual ICollection<CompletedSoloChallenge> CompletedSoloChallenges { get; set; }
    public virtual ICollection<RequestToCompleteSoloChallenge> RequestsToCompleteSoloChallenge { get; set; }
}
