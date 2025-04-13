using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;
using TaskManagementApp.BusinessLayer.Services.Security;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.UserHandlers
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, TokenResult>
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtService _jwtService;

        public LoginUserQueryHandler(IUserService userService, IPasswordHasher passwordHasher, IJwtService jwtService)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
            _jwtService = jwtService;
        }

        public async Task<TokenResult> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.Hash(request.Password);

            var user = await _userService.GetByEmailAsync(request.Email);
            if (user == null || user.PasswordHash != hashedPassword)
                return null;

            var token = _jwtService.CreateToken(user);

            return new TokenResult
            {
                Token = token,
                Expiration = DateTime.UtcNow.AddMinutes(60)
            };
        }
    }
}
