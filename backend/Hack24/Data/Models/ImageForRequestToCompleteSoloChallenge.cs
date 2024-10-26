using System.ComponentModel.DataAnnotations;

namespace Hack24.Data.Models;
public class ImageForRequestToCompleteSoloChallenge
{
    [Key]
    public int Id { get; set; }

    public byte[] Image { get; set; }

    public int RequestToCompleteSoloChallengeId { get; set; }
    public virtual RequestToCompleteSoloChallenge RequestToCompleteSoloChallenge { get; set; }
}
