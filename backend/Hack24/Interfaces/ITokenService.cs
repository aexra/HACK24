using Hack24.Data.Models;

namespace Hack24.Interfaces;

public interface ITokenService
{
    public Task<string> CreateToken(User user);
}
