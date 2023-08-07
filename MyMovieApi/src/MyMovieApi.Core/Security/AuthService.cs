using MyMovieApi.Core.Entities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using MyMovieApi.Core.Helper;
using MyMovieApi.Core.Interfaces;

namespace MyMovieApi.Core.Security
{

    public class AuthService : IAuthService
    {
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        public AuthService(IConfiguration configuration)
        {
            _key = SettingsConfigurationHelper.GetValue("JwtSettings:Key", configuration);
            _issuer = SettingsConfigurationHelper.GetValue("JwtSettings:Issuer", configuration);
            _audience = SettingsConfigurationHelper.GetValue("JwtSettings:Audience", configuration);
        }
        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _issuer,
                Audience = _audience,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.NickName.ToString()),
                    new Claim(ClaimTypes.Role, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}