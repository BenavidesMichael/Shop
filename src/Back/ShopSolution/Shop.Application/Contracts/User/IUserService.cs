using Shop.Application.Features.Auths.Users.Commands.Register;

namespace Shop.Application.Contracts.User
{
    public interface IUserService
    {
        Task<Models.User?> GetByEmailAsync(string email);
        Task<Models.User?> GetByUserNameAsync(string email);
        Task<bool> SignIn(string email, string password);
        Task<bool> AddUser(RegisterCommand user, string password);
    }
}
