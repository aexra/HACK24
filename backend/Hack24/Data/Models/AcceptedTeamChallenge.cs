using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;

[PrimaryKey("TeamId", [ "TeamChallengeId" ])]
public class AcceptedTeamChallenge
{
    [Key, Column(Order = 0)]
    public int TeamId { get; set; }

    [Key, Column(Order = 1)]
    public int TeamChallengeId { get; set; }

    [ForeignKey("TeamId")]
    public virtual Team Team { get; set; }

    [ForeignKey("TeamChallengeId")]
    public virtual TeamChallenge TeamChallenge { get; set; }
}
