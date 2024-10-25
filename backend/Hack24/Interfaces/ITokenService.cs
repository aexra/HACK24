using Web.Data.Models;

namespace Web.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(User user);
}
