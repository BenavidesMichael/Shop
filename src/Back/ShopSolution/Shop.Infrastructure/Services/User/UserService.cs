using Microsoft.AspNetCore.Identity;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Contracts.User;
using Shop.Application.Exceptions;
using Shop.Application.Features.Auths.Users.Commands.Register;
using Shop.Application.Models;
using Shop.Application.Models.Images;
using Shop.Infrastructure.Context;

namespace Shop.Infrastructure.Services.User
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IImageManageService _imageManageService;

        public UserService(
            SignInManager<ApplicationUser> signInManager,
             IImageManageService imageManageService,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _imageManageService = imageManageService;
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

        public async Task<Application.Models.User?> GetByUserNameAsync(string email)
        {
            var user = await _userManager.FindByNameAsync(email!);

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

        public async Task<bool> AddUser(RegisterCommand user, string password)
        {
            if (user.Avatar is not null)
            {
                ImageData image = new ImageData
                {
                    ImageStram = user.Avatar!.OpenReadStream(),
                    Name = user.Avatar!.Name,
                };

                var imageResponse = await _imageManageService.UploadImage(image);
                user.AvatarUrl = imageResponse.ImageUrl;
            }

            ApplicationUser newUser = new ApplicationUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                UserName = user.UserName,
                AvatarUrl = user.AvatarUrl,
                PhoneNumber = user.Phone,
            };

            var result = await _userManager.CreateAsync(newUser, password!);

            if (!result.Succeeded)
            {
                throw new BadRequestException("Error creating user");
            }

            await _userManager.AddToRoleAsync(newUser, RoleAuth.USER);
            return result.Succeeded;
        }
    }
}
