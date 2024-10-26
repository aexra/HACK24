using Web.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Hack24.Data.Models;

[PrimaryKey("UserId", [ "SoloChallengeId" ])]
public class CompletedSoloChallenge
{
    [Key, Column(Order = 0)]
    public string UserId { get; set; }

    [Key, Column(Order = 1)]
    public int SoloChallengeId { get; set; }

    public int Place { get; set; }
    public int Number { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(SoloChallengeId))]
    public virtual SoloChallenge SoloChallenge { get; set; }
}