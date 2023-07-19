using MediatR;
using Shop.Application.Contracts.User;
using Shop.Application.Exceptions;
using Shop.Application.Features.Auths.Users.Models;

namespace Shop.Application.Features.Auths.Users.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, LoginResponse>
{
    private readonly IUserService _userService;

    public RegisterCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<LoginResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        bool exist = await _userService.GetByEmailAsync(request.Email) is null;
        if (!exist) throw new BadRequestException("Email already exist");

        bool existUser = await _userService.GetByUserNameAsync(request.UserName) is not null;
        if (existUser) throw new BadRequestException("UserName already exist");

        bool response = await _userService.AddUser(request, request.Password);
        if (!response) throw new BadRequestException("Something went wrong");

        var user = await _userService.GetByEmailAsync(request.Email);
        return new LoginResponse
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            UserName = user.UserName,
            AvatarUrl = user.AvatarUrl,
            Roles = user.Roles,
        };
    }
}
