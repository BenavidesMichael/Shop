namespace Shop.Application.Contracts.User
{
    public interface IUserService
    {
        Task<Models.User> GetByEmailAsync(string email);
        Task<bool> SignIn(string email, string password);
    }
}
