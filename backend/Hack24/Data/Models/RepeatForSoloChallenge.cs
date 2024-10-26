using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class RepeatForSoloChallenge
{
    public byte RestPeriodInDays { get; set; }

    [Key, Column(Order = 0)]
    public int SoloChallengeId { get; set; }

    [ForeignKey(nameof(SoloChallengeId))]
    public virtual SoloChallenge SoloChallenge { get; set; }
}
