using System.ComponentModel.DataAnnotations;

namespace Hack24.Data.Models;
public class Level
{
    [Key]
    public int Id { get; set; }

    public int MinimalExp { get; set; }

    public byte[]? Image { get; set; }
}
