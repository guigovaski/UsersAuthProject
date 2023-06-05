using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsersAuth.Interfaces;
using UsersAuth.Models;

namespace UsersAuth.Services;

public class TokenService : ITokenService
{
    private IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
            new Claim(ClaimTypes.Role, "User")
        };

        var keySecret = _configuration["Jwt:Key"];

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keySecret));

        var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwtToken = new JwtSecurityToken(
            expires: DateTime.Now.AddDays(1),
            claims: claims,
            signingCredentials: signInCredentials,
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"]
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
