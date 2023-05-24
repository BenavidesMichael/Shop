using FluentValidation;

namespace Shop.Application.Features.Auths.Users.Commands.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            this.RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required");

            this.RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required");
        }
    }
}
