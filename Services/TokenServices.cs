using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MyExtensionRoles;
using MyJwtKey;
using MyUser;



namespace MyTokenServices;

public class TokenService
{
    public string TokenGenerator(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var Key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var getClaim = user.GetClaims();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(getClaim),
            Expires = DateTime.UtcNow.AddHours(6),
            SigningCredentials = new SigningCredentials (
                new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}