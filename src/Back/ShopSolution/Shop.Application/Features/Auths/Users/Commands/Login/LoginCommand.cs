using MediatR;
using Shop.Application.Features.Auths.Users.Models;

namespace Shop.Application.Features.Auths.Users.Commands.Login
{
    public class LoginCommand : IRequest<LoginResponse>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
