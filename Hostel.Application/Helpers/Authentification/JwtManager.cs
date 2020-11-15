using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hostel.Application.Helpers.Authentification
{
    public class JwtManager : IJwtManager
    {
        private readonly IConfiguration _configuration;
        
        public JwtManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> CreateJwt(Guid userId, string email)
        {
            var secret = GetSecret();
            var jwTokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = SetClaimsIdentity(userId, email),
                Audience = _configuration["Secret:HostelAudience"],
                Issuer = _configuration["Secret:HostelIssuer"],
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = secret
            };
            
            var jwt = new JwtSecurityTokenHandler().CreateToken(jwTokenDescriptor);
            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(jwt));
        }

        private ClaimsIdentity SetClaimsIdentity(Guid userId,string email)
        {
            return new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
            });
        }
        
        private SigningCredentials GetSecret()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes( _configuration["Secret:HostelSecret"]));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
    }
}