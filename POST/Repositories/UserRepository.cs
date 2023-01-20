using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using POST.Data;
using POST.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace POST.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> userManager;

        public SignInManager<ApplicationUser> signInManager { get; }

        private readonly IConfiguration configuration;

        public UserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration) { 
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        public async Task<string> SigninAsync(SigninModel model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if(!result.Succeeded)
            {
                return string.Empty;
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignupModel model)
        {
            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            return await userManager.CreateAsync(user, model.Password);
        }
    }
}
