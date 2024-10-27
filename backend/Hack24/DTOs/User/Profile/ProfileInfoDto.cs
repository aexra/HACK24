using Hack24.DTOs.Post;

namespace Hack24.DTOs;
public class ProfileInfoDto
{
    public string? Id { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public byte[]? Image { get; set; }
    public string? Bio { get; set; }
    public string? Hobby { get; set; }
    public string? Pets { get; set; }
    public string? FamilyInviteKey { get; set; }
    public string? Telegram { get; set; }
    public string? VK { get; set; }
    public PostDto? Post { get; set; }
}
