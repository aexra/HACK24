using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;

[PrimaryKey("TeamId", [ "TeamChallengeId" ])]
public class CompletedTeamChallenge
{
    [Key]
    public int TeamId { get; set; }

    [Key]
    public int TeamChallengeId { get; set; }

    [ForeignKey(nameof(TeamId))]
    public virtual Team Team { get; set; }

    [ForeignKey(nameof(TeamChallengeId))]
    public virtual TeamChallenge Challenge { get; set; }
}
