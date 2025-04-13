using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.UserHandlers
{
    public class GetUserQueryHandlers : IRequestHandler<GetAllUsersQuery,List<GetAllUsersQueryResult>>
    {
        private readonly IUserService _userService;

        public GetUserQueryHandlers(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<GetAllUsersQueryResult>> Handle(GetAllUsersQuery request,CancellationToken cancellationToken)
        {
            var users = await _userService.GetAllWithRoleAsync();

            var result = users.Select(user => new GetAllUsersQueryResult
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = user.Role?.RoleName,
                CreatedDate = user.CreatedDate
            }).ToList();

            return result;  
        }
}
}
