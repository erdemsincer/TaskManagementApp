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
            var task = await _taskItemService.GetTaskItemWithProjectAndCommentsAsync(request.Id);
            if (task == null) return null;

            return new GetTaskItemByIdQueryResult
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                CreatedDate = task.CreatedDate,
                Deadline = task.Deadline,
                ProjectId = task.ProjectId,
                ProjectTitle = task.Project?.Title,
                AssignedToUser = task.AssignedToUser?.FullName,
                Comments = task.Comments.Select(c => new TaskItemCommentResult
                {
                    Id = c.Id,
                    Content = c.Content,
                    CreatedDate = c.CreatedDate,
                    UserId = c.UserId,
                    UserFullName = c.User?.FullName
                }).ToList()
            };
        }
    }
}
