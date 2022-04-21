using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Restaurante.UI.Utils;

public static class JwtParser
{
    public static IEnumerable<Claim> ParseClaimsFromJwt(string token)
    {
        return ParseJwt(token).Claims;
    }

    private static JwtSecurityToken ParseJwt(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        if (handler.CanReadToken(token) == false)
        {
            return null;
        }

        return handler.ReadJwtToken(token);
    }

    /// <summary>
    /// Extrai multiplas roles contidas na mesma claim.
    /// </summary>
    /// <param name="claims"></param>
    /// <param name="keyValuePairs"></param>
    private static void ExtractRolesFromJwt (List<Claim> claims, Dictionary<string, object> keyValuePairs)
    {
        keyValuePairs.TryGetValue(ClaimTypes.Role, out var roles);

        if (roles is null) return;

        var parsedRoles = roles.ToString().Trim().TrimStart('[').TrimEnd(']').Split(',');

        if (parsedRoles.Length > 1)
        {
            foreach (var parsedRole in parsedRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, parsedRole.Trim('"')));
            }
        }

        keyValuePairs.Remove(ClaimTypes.Role);
    }
}
