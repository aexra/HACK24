using Hack24.Data.Models;

namespace Web.DTOs.Challenge.Me;

internal class MyChallengesDto
{
    public ICollection<AcceptedSoloChallenge> Accepted { get; set; }
    public ICollection<CompletedSoloChallenge> Completed { get; set; }
    public IDictionary<string, int> Counters { get; set; }
}
