using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class TeamChallengeCatalog
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }

    public int ChallengeTypeId { get; set; }

    public int TeamTypeId { get; set; }

    public bool IsVoting { get; set; }

    [ForeignKey(nameof(ChallengeTypeId))]
    public virtual ChallengeType ChallengeType { get; set; }

    [ForeignKey(nameof(TeamTypeId))]
    public virtual TeamType TeamType { get; set; }

    public virtual ICollection<TeamChallenge> Challenges { get; set; }
}
