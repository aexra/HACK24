using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Data.Models;

namespace Hack24.Data.Models;
public class SoloSelfChallengeCatalog
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public int ChallengeTypeId { get; set; }

    public string UserId { get; set; }
    
    [ForeignKey(nameof(ChallengeTypeId))]
    public virtual ChallengeType ChallengeType { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    public virtual ICollection<SoloSelfChallenge> Challenges { get; set; }
}
