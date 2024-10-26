using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;

public class RepeatForSoloSelfChallenge
{
    [Key]
    public int SoloSelfChallengeId { get; set; }

    [ForeignKey(nameof(SoloSelfChallengeId))]
    public virtual SoloSelfChallenge SoloSelfChallenge { get; set; }

    public byte RestPeriodInDays { get; set; }
}
