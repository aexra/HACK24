using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class RepeatForTeamSelfChallenge
{
    [Key]
    public int TeamSelfChallengeId { get; set; }

    public byte RestPeriodInDays { get; set; }

    [ForeignKey(nameof(TeamSelfChallengeId))]
    public virtual TeamSelfChallenge Challenge { get; set; }
}
