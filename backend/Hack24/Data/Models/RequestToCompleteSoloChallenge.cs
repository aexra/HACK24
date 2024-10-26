using System.ComponentModel.DataAnnotations;
using Web.Data.Models;

namespace Hack24.Data.Models;
public class RequestToCompleteSoloChallenge
{
    [Key]
    public int Id { get; set; }

    public string Text { get; set; }
    public int? Number { get; set; }

    public string UserId { get; set; }
    public virtual User User { get; set; }

    public int SoloChallengeId { get; set; }
    public virtual SoloChallenge SoloChallenge { get; set; }

    public virtual ICollection<ImageForRequestToCompleteSoloChallenge> Images { get; set; }
}
