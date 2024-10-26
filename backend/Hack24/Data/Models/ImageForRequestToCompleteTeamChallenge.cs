using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hack24.Data.Models;
public class ImageForRequestToCompleteTeamChallenge
{
    [Key]
    public int Id { get; set; }

    public int RequestToCompleteTeamChallengeId { get; set; }

    public byte[] Image { get; set; }

    [ForeignKey(nameof(RequestToCompleteTeamChallengeId))]
    public virtual RequestToCompleteTeamChallenge RequestToCompleteTeamChallenge { get; set; }
}
