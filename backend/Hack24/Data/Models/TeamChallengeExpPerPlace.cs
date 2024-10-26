using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;

[PrimaryKey("TeamChallengeId", [ "Place" ])]
public class TeamChallengeExpPerPlace
{
    [Key]
    public int TeamChallengeId { get; set; }

    [Key]
    public int Place { get; set; }

    [ForeignKey(nameof(TeamChallengeId))]
    public virtual TeamChallenge Challenge { get; set; }
}
