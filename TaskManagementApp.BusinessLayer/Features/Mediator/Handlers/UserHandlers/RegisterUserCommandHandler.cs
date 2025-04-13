using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.UserCommands;
using TaskManagementApp.BusinessLayer.Services.Security;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.UserHandlers
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterUserCommandHandler(IUserService userService, IPasswordHasher passwordHasher)
        {
            _userService = userService;
            _passwordHasher = passwordHasher;
        }

        public async Task Handle(RegisterUserCommand request,CancellationToken cancellationToken)
        {
            var hashedPassword = _passwordHasher.Hash(request.Password);

            await _userService.AddAsync(new EntityLayer.Entities.User
            {
                FullName = request.FullName,
                Email = request.Email,
                PasswordHash = hashedPassword,
                RoleId = 2,
                CreatedDate = DateTime.UtcNow
            });
        }

        
    }
}
