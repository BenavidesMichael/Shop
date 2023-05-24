using Shop.Application.Features.Auths.Users.Commands.Login;

namespace Shop.Application.Contracts.Identity
{
    public interface IAuthService
    {
        string? GetSessionUser();
        string CtreateToken(string email);
    }
}
