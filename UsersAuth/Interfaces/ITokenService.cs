using UsersAuth.Models;

namespace UsersAuth.Interfaces;

public interface ITokenService
{
    public string GenerateToken(User user);
}
