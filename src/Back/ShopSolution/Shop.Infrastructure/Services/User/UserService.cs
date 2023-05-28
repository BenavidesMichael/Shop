using Microsoft.AspNetCore.Identity;
using Shop.Application.Contracts.User;
using Shop.Infrastructure.Context;

namespace Shop.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<Application.Models.User?> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email!);

            if (user is null) return default;

            var role = await _userManager.GetRolesAsync(user!);

            return new Application.Models.User
            {
                FirstName = user!.FirstName,
                LastName = user!.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                UserName = user.UserName,
                AvatarUrl = user!.AvatarUrl,
                IsActive = user!.IsActive,
                Roles = role,
            };
        }

        public async Task<bool> SignIn(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email!);
            var result = await _signInManager.CheckPasswordSignInAsync(user!, password!, false);
            return result.Succeeded;
        }
    }
}
