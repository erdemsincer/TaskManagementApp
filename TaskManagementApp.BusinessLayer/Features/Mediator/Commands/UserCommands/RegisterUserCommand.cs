using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.UserCommands
{
    public class RegisterUserCommand : IRequest
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Hashlenecek
        
    }
}
