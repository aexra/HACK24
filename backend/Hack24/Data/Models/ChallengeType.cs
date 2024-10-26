using System.ComponentModel.DataAnnotations;

namespace Hack24.Data.Models;
public class ChallengeType
{
    [Key]
    public int Id { get; set; }
    public string ChallengeName { get; set; }

    public virtual ICollection<SoloChallengeCatalog> SoloChallengeCatalogs { get; set; }
    public virtual ICollection<SoloSelfChallengeCatalog> SoloSelfChallengeCatalogs { get; set; }
}
