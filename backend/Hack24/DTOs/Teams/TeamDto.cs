using Hack24.Data.Models;

namespace Hack24.DTOs.Teams;
public class TeamDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public TeamType Type { get; set; }
    public IEnumerable<User> Members { get; set; }

    public ICollection<RequestToCompleteTeamChallenge> CompleteRequests { get; set; }
    public ICollection<TeamChallenge> CompletedChallenges { get; set; }
    public ICollection<TeamChallenge> AcceptedChallenges { get; set; }
}
