using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class SoloSelfChallenge
{
    [Key]
    public int Id { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int SoloSelfChallengeCatalog { get; set; }

    [ForeignKey(nameof(SoloSelfChallengeCatalog))]
    public virtual SoloSelfChallengeCatalog Catalog { get; set; }
}
