using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class GetTaskItemByIdQueryHandler : IRequestHandler<GetTaskItemByIdQuery,GetTaskItemByIdQueryResult>
    {
        private readonly ITaskItemService _taskItemService;

        public GetTaskItemByIdQueryHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task<GetTaskItemByIdQueryResult> Handle(GetTaskItemByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _taskItemService.GetByIdAsync(request.Id);
            return new GetTaskItemByIdQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                ProjectId = values.ProjectId,
                AssignedToUserId = values.AssignedToUserId,
                Status = values.Status,
                Priority = values.Priority,
                Deadline = values.Deadline,
                CreatedDate = values.CreatedDate,
                Comments = values.Comments.Select(comment => new TaskItemCommentResult
                {
                    Id = comment.Id,
                    UserId = comment.UserId,
                    Content = comment.Content,
                    CreatedDate = comment.CreatedDate
                }).ToList()
            };
        }
    }
}
