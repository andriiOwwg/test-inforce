using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using test_inforce_test_1.Configurations;

namespace test_inforce_test_1.Helpers;
public class JwtGenerator
{
  private readonly JwtConfig _jwtConfig;

  public JwtGenerator(IOptionsMonitor<JwtConfig> _optionsMonitor)
  {
    _jwtConfig =  _optionsMonitor.CurrentValue;
  }

  public string GenerateJwtToken(IdentityUser user)
  {
    var jwtTokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = new ClaimsIdentity(new[]
      {
        new Claim("Id", user.Id),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      }),
      Expires = DateTime.UtcNow.AddHours(6),
      SigningCredentials = new SigningCredentials(
        new SymmetricSecurityKey(key),
        SecurityAlgorithms.HmacSha512
      )
    };

    var token = jwtTokenHandler.CreateToken(tokenDescriptor);
    var jwtToken = jwtTokenHandler.WriteToken(token);

    return jwtToken;
  }
}