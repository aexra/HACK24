using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class Team 
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public int TeamTypeId { get; set; }

    [ForeignKey(nameof(TeamTypeId))]
    public virtual TeamType Type { get; set; }

    public virtual ICollection<RequestToCompleteTeamChallenge> CompleteRequests { get; set; }
    public virtual ICollection<CompletedTeamChallenge> CompletedChallenges { get; set; }
    public virtual ICollection<AcceptedTeamChallenge> AcceptedChallenges { get; set; }
    public virtual ICollection<UserTeam> UserTeams { get; set; }
}
