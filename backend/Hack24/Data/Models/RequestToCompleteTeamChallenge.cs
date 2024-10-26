using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class RequestToCompleteTeamChallenge
{
    [Key]
    public int Id { get; set; }

    public int TeamId { get; set; }

    public int TeamChallengeId { get; set; }

    public string Text { get; set; }

    [ForeignKey(nameof(TeamId))]
    public virtual Team Team { get; set; }

    [ForeignKey(nameof(TeamChallengeId))]
    public virtual TeamChallenge Challenge { get; set; }

    public virtual ICollection<ImageForRequestToCompleteTeamChallenge> Images { get; set; }
}
