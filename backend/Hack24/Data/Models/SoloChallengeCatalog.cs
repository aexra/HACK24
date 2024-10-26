using System.ComponentModel.DataAnnotations;

namespace Hack24.Data.Models;
public class SoloChallengeCatalog
{
    [Key]
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public bool IsVoting { get; set; }

    public int ChallengeTypeId { get; set; }
    public ChallengeType ChallengeType { get; set; }
}
