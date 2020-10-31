using AppSettingsManager.Entities;
using AppSettingsManager.Settings;

using Microsoft.IdentityModel.Tokens;

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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
					new Claim(ClaimTypes.Name, user.UserName),
				}),
				Expires = DateTime.UtcNow.AddMinutes(_jwtTokenSettings.ExpiresAfterMinutes),
				Issuer = _jwtTokenSettings.Issuer,
				Audience = _jwtTokenSettings.Audience,
				SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

        public User ParseToken(string token)
        {
			var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtTokenSettings.Secret));

			var tokenHandler = new JwtSecurityTokenHandler();

			var claimsPrincipal = tokenHandler.ValidateToken(token, new TokenValidationParameters {
				RequireExpirationTime = true,
				ValidateIssuer = true,
				RequireAudience = true,
				ValidIssuer = _jwtTokenSettings.Issuer,
				ValidateAudience = true,
				ValidAudience = _jwtTokenSettings.Audience,
				IssuerSigningKey = securityKey,
			}, out var securityToken);

			return new User
			{
				Id = int.Parse(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
				LastAccessToken = token,
				UserName = claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.Name).Value
			};
		}
    }
}
