using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class GetTaskItemQueryHandler : IRequestHandler<GetTaskItemQuery, List<GetTaskItemQueryResult>>
    {
        private readonly ITaskItemService _taskItemService;

        public GetTaskItemQueryHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task<List<GetTaskItemQueryResult>> Handle(GetTaskItemQuery request, CancellationToken cancellationToken)
        {
            var values = await _taskItemService.GetAllAsync();
            var result = values.Select(t => new GetTaskItemQueryResult
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                CreatedDate = t.CreatedDate,
                Status = t.Status,
                Priority = t.Priority,
                Deadline = t.Deadline,
                ProjectId = t.ProjectId,
                AssignedToUserId = t.AssignedToUserId,
                Comments = t.Comments.Select(c => new TaskItemCommentResult
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    Content = c.Content,
                    CreatedDate = c.CreatedDate
                }).ToList()
            }).ToList();

            return result;
        }
    }
}
