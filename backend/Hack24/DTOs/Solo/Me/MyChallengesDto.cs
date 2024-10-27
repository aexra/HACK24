using Hack24.Data.Models;

namespace Hack24.DTOs.Solo.Me;
public class MyChallengesDto
{
    public ICollection<AcceptedSoloChallenge> Accepted { get; set; }
    public ICollection<CompletedSoloChallenge> Completed { get; set; }
    public IDictionary<string, int> Counters { get; set; }
}
