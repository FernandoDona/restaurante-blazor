using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Restaurante.AuthProvider.API.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Restaurante.AuthProvider.API.Services;

public class TokenService
{
    private string _key = "chave-super-segura-geradora-de-token";
    public string CreateToken(IdentityUser<int> identityUser)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, identityUser.UserName),
            new Claim(ClaimTypes.NameIdentifier, identityUser.Id.ToString()),
            new Claim(ClaimTypes.Email, identityUser.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: claims,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
