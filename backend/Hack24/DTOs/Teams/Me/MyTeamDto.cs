using Hack24.Data.Models;

namespace Hack24.DTOs.Teams.Me;
public class MyTeamDto
{
    public ICollection<AcceptedTeamChallenge> Accepted { get; set; }
    public ICollection<CompletedTeamChallenge> Completed { get; set; }
    public IEnumerable<User> Members { get; set; }
    public Team Team { get; set; }
}
