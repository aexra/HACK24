using System.ComponentModel.DataAnnotations;

namespace Hack24.DTOs;
public class RegisterDto
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string RegisterKey { get; set; }
}
