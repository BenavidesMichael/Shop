using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.Contracts.Identity;
using Shop.Application.Contracts.User;
using Shop.Application.Models.AppSettings;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Infrastructure.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public JWTSetting JwtSetting { get; }
        public ILogger<AuthService> Logger { get; }

        public AuthService(
            IOptions<JWTSetting> options,
            ILogger<AuthService> logger,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService
            )
        {
            Logger = logger;
            JwtSetting = options.Value;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public string CtreateToken([NotNull] string email)
        {
            var user = _userService.GetByEmailAsync(email!).Result;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user?.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user?.Email!),
                new Claim(JwtRegisteredClaimNames.Email, user?.Email!),
                new Claim(JwtRegisteredClaimNames.GivenName, user?.FirstName!),
                new Claim(JwtRegisteredClaimNames.FamilyName, user?.LastName!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            };

            foreach (var role in user?.Roles!)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting.Key!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddHours(1);
            var token = new JwtSecurityToken(JwtSetting.Issuer, JwtSetting.Issuer, claims, expires: expires, signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string? GetSessionUser()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user != null)
            {
                string? email = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
                return email;
            }

            return null;
        }
    }
}
