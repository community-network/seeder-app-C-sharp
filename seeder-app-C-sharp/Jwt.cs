using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace seeder_app_C_sharp;

internal class Jwt
{
    public static string Create(Guid guid, string dataString)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var now = DateTime.UtcNow;

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim( "guid", guid.ToString() ),
                new Claim( "post", dataString)
            }),
            Expires = now.AddMinutes(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("aErOexSMBHSjEMvWat4zIg1g8w9VbESICnNCjCpAX73SJPK87+rWb0NqCsD3RHX7eQu498Svr0PivjW91Rq38r5+FjY1UpajuAUbUm5ZQv/KjT41gntWs4r8QZfCc2dM5F8PNSYDoVjhz+y9AJ+nbe7YwkIImycnhZyvKTBmm8qMYhrnJIp6OEipTVFmXweciuns5rnJGFKUpM95UMSf/gkCwSpuftkdFWgGMWD/b5Z1twn9ni7eOEKO8NBM8ikG9W4Pw6IHZqzpnQRh7tPn6gjKbxVzW4tBCrV+aIrWRfkYhNb72OOTWoMdT2oYcDyJQRaNlch6MA2s4Y677SIKwg==")), SecurityAlgorithms.HmacSha256),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

}
