using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class RepeatForTeamChallenge
{
    [Key]
    public int TeamChallengeId { get; set; }

    public byte RestPeriodInDays { get; set; }

    [ForeignKey(nameof(TeamChallengeId))]
    public virtual TeamChallenge Challenge { get; set; }
}
