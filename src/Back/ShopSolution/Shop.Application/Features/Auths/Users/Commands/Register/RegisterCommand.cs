using MediatR;
using Microsoft.AspNetCore.Http;
using Shop.Application.Features.Auths.Users.Models;

namespace Shop.Application.Features.Auths.Users.Commands.Register;

public class RegisterCommand : IRequest<LoginResponse>
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public IFormFile? Avatar { get; set; }
    public string? AvatarUrl { get; set; }
    public required string Password { get; set; }
    public required string UserName { get; set; }
}
