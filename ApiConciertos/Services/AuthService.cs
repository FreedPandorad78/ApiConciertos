using ApiConciertos.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiConciertos.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<IdentityUser> Register(string email, string password, string role)
        {
            var user = new IdentityUser { UserName = email, Email = email };
            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded) {
                if (!await _roleManager.RoleExistsAsync(role)) {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }

                await userManager.AddToRoleAsync(user, role);
            }

            return result;
        }

        public async Task<String?> Login(string email, string password) {
            var user = await userManager.FindByEmailAsync(email);

            if (user != null && await userManager.CheckPasswordAsync(user, password)){
                var userRoles = await userManager.GetRolesAsync(user);
                return GenerarJetToken(user, userRoles);
            }
            return null;
        }

        private string GenerarJetToken(IdentityUser user, IList<string> roles) {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var authFirmaKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration["Jet:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _configuration["Jet:Issuer"],
                audience: _configuration["Jet:Audience"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authFirmaKey, SecurityAlgorithms.HmacSha256)

                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
