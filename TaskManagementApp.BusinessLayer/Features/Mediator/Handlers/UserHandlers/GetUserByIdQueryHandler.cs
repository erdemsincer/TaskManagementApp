using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.UserHandlers
{
    public class GetUserByIdQueryHandler:IRequestHandler<GetUserByIdQuery,GetUserByIdQueryResult>
    {
        private readonly IUserService _userService;

        public GetUserByIdQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetByIdAsync(request.Id);
            if (user == null)
            {
                return null;
            }

            return new GetUserByIdQueryResult
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = user.Role?.RoleName,
                CreatedDate = user.CreatedDate
            };
        }
    }
}
