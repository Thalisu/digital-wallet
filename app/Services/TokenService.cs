using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using app.Interfaces;
using app.Models;
using Microsoft.IdentityModel.Tokens;

namespace app.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            var jwtKey = _config["Jwt:SigningKey"];
            if (jwtKey == null)
            {
                throw new ArgumentNullException(
                    "Define Jwt:SigningKey in appsettings.json"
                );
            }

            _key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            );
        }
        public string CreateToken(AppUser user)
        {
            if (user == null || user.Email == null || user.UserName == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var claims = new List<Claim>{
                new(JwtRegisteredClaimNames.Email, user.Email),
                new(JwtRegisteredClaimNames.GivenName, user.UserName)
            };

            var creds = new SigningCredentials(
                _key, SecurityAlgorithms.HmacSha512Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
