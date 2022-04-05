using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FoodbWebAPI.Helpers;
using FoodbWebAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FoodbWebAPI.Auth
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IDictionary<string, string> users = new Dictionary<string, string>
        {{"admin", "admin"}, {"username", "password"}};
        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
        }
        
        public string GenerateToken(User user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                 new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public int? ValidateToken(string token)
        {
            if (token == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.key);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out var securityToken);

                var jwtSecurityToken = securityToken as JwtSecurityToken;
                var userId = int.Parse(jwtSecurityToken.Claims.First(c => c.Type == "id").Value);

                // Return user id if token is valid
                return userId;
            }
            catch (System.Exception)
            {
                // Return null if token is invalid
                return null;
            }
        }
    }
}