using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace Services;

public class TokenService : ITokenService
{
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(TokenSettings.Secret);
        var tokenDescripetor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddHours(6), // Duração do token
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            ), // Credenciais usadas para encriptar e decriptar o token
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()), // ClaimTypes.Name mapeia para User.Identity.Name
                new Claim(ClaimTypes.Role, user.Role.ToString()) // ClaimTypes.Role mapeia para User.IsInRole
            }) // Perfis do usuário
        };

        var token = tokenHandler.CreateToken(tokenDescripetor);
        return tokenHandler.WriteToken(token);
    }
}
