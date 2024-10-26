using System.ComponentModel.DataAnnotations;

namespace Hack24.Data.Models;
public class TeamType
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
}
