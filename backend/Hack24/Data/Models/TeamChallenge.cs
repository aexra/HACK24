using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class TeamChallenge
{
    [Key]
    public int Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int TeamChallengeCatalogId { get; set; }

    [ForeignKey(nameof(TeamChallengeCatalogId))]
    public virtual TeamChallengeCatalog Catalog { get; set; }

    public virtual ICollection<TeamChallengeExpPerPlace> Exps { get; set; }
}
