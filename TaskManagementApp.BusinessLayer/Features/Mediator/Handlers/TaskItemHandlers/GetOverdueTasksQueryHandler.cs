using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class GetOverdueTasksQueryHandler : IRequestHandler<GetOverdueTasksQuery, List<UserTaskResult>>
    {
        private readonly ITaskItemService _taskItemService;

        public GetOverdueTasksQueryHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task<List<UserTaskResult>> Handle(GetOverdueTasksQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskItemService.GetOverdueTasksAsync();

            return tasks.Select(t => new UserTaskResult
            {
                Id = t.Id,
                Title = t.Title,
                Status = t.Status,
                Deadline = t.Deadline
            }).ToList();
        }
    }
}
