using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class GetTasksByStatusQueryHandler : IRequestHandler<GetTasksByStatusQuery, List<UserTaskResult>>
    {
        private readonly ITaskItemService _taskItemService;

        public GetTasksByStatusQueryHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task<List<UserTaskResult>> Handle(GetTasksByStatusQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskItemService.GetTasksByStatusAsync(request.Status);

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
