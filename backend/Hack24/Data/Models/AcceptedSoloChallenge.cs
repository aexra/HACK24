using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hack24.Data.Models;

namespace Hack24.Data.Models;

[PrimaryKey("UserId", [ "SoloChallengeId" ])]
public class AcceptedSoloChallenge
{
    [Key, Column(Order = 0)]
    public string UserId { get; set; }

    [Key, Column(Order = 1)]
    public int SoloChallengeId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; }

    [ForeignKey("SoloChallengeId")]
    public virtual SoloChallenge SoloChallenge { get; set; }
}
