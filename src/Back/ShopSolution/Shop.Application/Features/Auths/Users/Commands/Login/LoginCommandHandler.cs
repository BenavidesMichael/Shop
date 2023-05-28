using MediatR;
using Shop.Application.Contracts.Identity;
using Shop.Application.Contracts.User;
using Shop.Application.Exceptions;
using Shop.Application.Features.Auths.Users.Models;
using Shop.Application.Persistence;
using Shop.Domain.Entities;

namespace Shop.Application.Features.Auths.Users.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IAuthService _authService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public LoginCommandHandler(
            IAuthService authService,
            IUnitOfWork unitOfWork,
            IUserService userService)
        {
            _authService = authService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByEmailAsync(request.Email!);
            if (user is null)
                throw new NotFoundExecption(nameof(user), request.Email!);

            if (!user.IsActive)
                throw new BadRequestException("User is not active");

            var connected = await _userService.SignIn(request.Email!, request.Password!);
            if (!connected)
                throw new BadRequestException("Username or password is incorrect");

            var adress = await _unitOfWork.Repository<Address>().GetEntityAsync(x => x.Username == user.UserName);

            var token = _authService.CtreateToken(request.Email!);
            return new LoginResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                UserName = user.UserName,
                AvatarUrl = user.AvatarUrl,
                Roles = user.Roles,
                //SendAddress = new SendAddress() 
                //{
                //    City = adress.City,
                //    Country = adress.Country,
                //    Street = adress.Street,
                //    Number = adress.Number,
                //    PostalCode = adress.PostalCode
                //},
                Token = token,
            };
        }
    }
}
