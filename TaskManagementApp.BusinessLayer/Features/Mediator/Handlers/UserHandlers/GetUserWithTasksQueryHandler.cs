using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.UserHandlers
{
    public class GetUserWithTasksQueryHandler :IRequestHandler<GetUserWithTasksQuery,GetUserWithTasksResult>
    {
        private readonly IUserService _userService;

        public GetUserWithTasksQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserWithTasksResult> Handle(GetUserWithTasksQuery request, CancellationToken cancellationToken)
        {
            var user = await _userService.GetUserWithAssignedTasksAsync(request.Id);
            if (user == null)
            {
                return null;
            }

            return new GetUserWithTasksResult
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                RoleName = user.Role.RoleName,
                CreatedDate = user.CreatedDate,
                AssignedTasks = user.AssignedTasks.Select(t => new UserTaskResult
                {
                    Id = t.Id,
                    Title = t.Title,
                    Status = t.Status.ToString(),
                    Deadline = t.Deadline
                }).ToList()
            };
        }
}
}
