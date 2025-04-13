using MediatR;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries
{
    public class LoginUserQuery : IRequest<TokenResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
