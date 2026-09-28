using EProcurementRefactor.Application.DTOs;
using EProcurementRefactor.Application.Interfaces;
using EProcurementRefactor.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EProcurementRefactor.Infrastructure.Services
{
    public class JwtTokenGenerator : IjwtTokenGenerator
    {
        private readonly TokenSettings _tokenSettings;
        public JwtTokenGenerator(IOptions<TokenSettings> options)
        {
            _tokenSettings = options.Value;
        }
        public string GenerateToken(SiacAdmin siacAdmin)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,siacAdmin.Username)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));

            var credintials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                issuer: _tokenSettings.Issuer,
                audience: _tokenSettings.Audience,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credintials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
