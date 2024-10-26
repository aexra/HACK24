using System.ComponentModel.DataAnnotations;

namespace Hack24.DTOs;
public class LoginDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
