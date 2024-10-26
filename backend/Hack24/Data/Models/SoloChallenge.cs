using Hack24.Data.Model;
using System.ComponentModel.DataAnnotations;

namespace Hack24.Data.Models;
public class SoloChallenge
{
    [Key]
    public int Id { get; set; }
    
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }

    public int SoloChallengeCatalogId { get; set; }
    public SoloChallengeCatalog SoloChallengeCatalog { get; set; }

    public virtual ICollection<SoloChallengeExpPerPlace> Exps { get; set; }
}
