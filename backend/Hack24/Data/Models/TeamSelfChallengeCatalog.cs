using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class TeamSelfChallengeCatalog
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public int ChallengeTypeId { get; set; }

    public int TeamId { get; set; }

    [ForeignKey(nameof(ChallengeTypeId))]
    public virtual ChallengeType ChallengeType { get; set; }
    
    [ForeignKey(nameof(TeamId))]
    public virtual Team Team { get; set; }

    public virtual ICollection<TeamSelfChallenge> Challenges { get; set; }
}
