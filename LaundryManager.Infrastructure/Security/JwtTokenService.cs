using LaundryManager.Domain.Contracts.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LaundryManager.Infrastructure.Security
{
    internal class JwtTokenService : IJwtTokenService
    {
        private readonly IConfiguration _Configuration;
        public JwtTokenService(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        public string GenerateToken(string userName)
        {
            var JwtKey = _Configuration.GetValue<string>("JwtKey");
            if (string.IsNullOrEmpty(JwtKey))
            {
                throw new ArgumentException("JWT Key is not configured in the application settings.");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(JwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.Name, userName)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwt = tokenHandler.WriteToken(token);

            return jwt;
        }
    }
}
