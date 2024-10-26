using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class TeamSelfChallenge
{
    [Key]
    public int Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int TeamSelfChallengeCatalogId { get; set; }

    [ForeignKey(nameof(TeamSelfChallengeCatalogId))]
    public virtual TeamSelfChallengeCatalog Catalog { get; set; }
}
