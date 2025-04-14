using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.UserQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.UserHandlers
{
    public class GetUserActivitySummaryQueryHandler : IRequestHandler<GetUserActivitySummaryQuery, GetUserActivitySummaryResult>
    {
        private readonly IUserService _userService;

        public GetUserActivitySummaryQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetUserActivitySummaryResult> Handle(GetUserActivitySummaryQuery request, CancellationToken cancellationToken)
        {
            var (taskCount, commentCount) = await _userService.GetUserActivitySummaryAsync(request.Id);

            return new GetUserActivitySummaryResult
            {
                TaskCount = taskCount,
                CommentCount = commentCount
            };
        }
}
}
