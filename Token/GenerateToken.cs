using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using newapi.domain.entities;

namespace newapi.token;

public class GenerateToken(string key)
{
    private SymmetricSecurityKey _securityKey = default!;
    private readonly string _key = key;

    public string Generate(User? user)
    {
        if (user == null)
        {   
            return "fail";
        }
        if (string.IsNullOrEmpty(_key))
        {
            return "fail";
        }

        _securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
        var credencials = new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new("Email", user.Email.ToString()),
            new("Name", user.Name),
            new(ClaimTypes.Role, user.Profile.ToString())
        };

        var token = new JwtSecurityToken(
            issuer: "https://myapi.local.com",
            audience: "api_pet_local",
            claims: claims,
            expires: DateTime.Now.AddDays(7),
            signingCredentials: credencials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);;
    }
}