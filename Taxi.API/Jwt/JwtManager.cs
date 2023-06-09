using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Taxi.DatabaseAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Taxi.API.Jwt
{
    public class JwtManager
    {
        private readonly TaxiDbContext _context;
        private readonly string _issuer;
        private readonly int _seconds;
        private readonly ITokenStorage _storage;
        private readonly string _secretKey;

        public JwtManager(
            TaxiDbContext context,
            string issuer,
            string secretKey,
            int seconds,
            ITokenStorage storage)
        {
            _context = context;
            _issuer = issuer;
            _secretKey = secretKey;
            _seconds = seconds;
            _storage = storage;
        }

        public string MakeToken(string username, string password)
        {
            
            var user = _context.Users
                                .Include(x => x.UserRole)
                                .ThenInclude(x => x.RoleUseCases)
                                .FirstOrDefault(x => x.Username == username && 
                                                     x.IsActive);

            var valid = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!valid)
            {
                throw new UnauthorizedAccessException("User with those credentials doesn't exist.");
            }

            if (user == null || user.UserRole == null || !user.UserRole.IsActive)
            {
                throw new UnauthorizedAccessException("User not found.");
            }

            int id = user.Id;
            List<int> useCases = user.UserRole.RoleUseCases.Select(x => x.UseCaseId).ToList();

            var tokenId = Guid.NewGuid().ToString();

            _storage.AddToken(tokenId);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, tokenId, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iss, _issuer, ClaimValueTypes.String, _issuer),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _issuer),
                new Claim("Id", id.ToString()),
                new Claim("Username", username),
                new Claim("UseCases", JsonConvert.SerializeObject(useCases))
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var now = DateTime.UtcNow;
            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: "Any",
                claims: claims,
                notBefore: now,
                expires: now.AddSeconds(_seconds),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
