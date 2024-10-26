using Hack24.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Model;

[PrimaryKey("SoloChallengeId", [ "Place" ])]
public class SoloChallengeExpPerPlace
{
    [Key, ForeignKey("SoloChallenge")]
    public int SoloChallengeId { get; set; }
    public virtual SoloChallenge SoloChallenge { get; set; }

    [Key]
    public int Place { get; set; }

    public int Experience { get; set; }
}
