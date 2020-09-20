using AppSettingsManager.Entities;
using AppSettingsManager.Settings;

using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppSettingsManager.Services
{
    public class JwtTokenService : IJwtTokenService
    {
		private readonly JwtTokenSettings _jwtTokenSettings;

        public JwtTokenService(JwtTokenSettings jwtTokenSettings)
        {
            _jwtTokenSettings = jwtTokenSettings;
        }

        public string Generate(User user)
        {
			var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtTokenSettings.Secret));

			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				}),
				Expires = DateTime.UtcNow.AddMinutes(_jwtTokenSettings.ExpiresAfterMinutes),
				Issuer = _jwtTokenSettings.Issuer,
				Audience = _jwtTokenSettings.Audience,
				SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
    }
}
