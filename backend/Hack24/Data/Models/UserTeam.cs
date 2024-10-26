using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Data.Models;

namespace Hack24.Data.Models;

[PrimaryKey("UserId", [ "TeamId" ])]
public class UserTeam
{
    [Key, Column(Order = 0)]
    public int UserId { get; set; }

    [Key, Column(Order = 1)]
    public int TeamId { get; set; }

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(TeamId))]
    public virtual Team Team { get; set; }
}
