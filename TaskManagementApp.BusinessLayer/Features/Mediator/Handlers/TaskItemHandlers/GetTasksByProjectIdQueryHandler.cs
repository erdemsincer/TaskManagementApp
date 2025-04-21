using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.TaskltemQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.TaskItemHandlers
{
    public class GetTasksByProjectIdQueryHandler : IRequestHandler<GetTasksByProjectIdQuery, List<UserTaskResult>>
    {
        private readonly ITaskItemService _taskItemService;

        public GetTasksByProjectIdQueryHandler(ITaskItemService taskItemService)
        {
            _taskItemService = taskItemService;
        }

        public async Task<List<UserTaskResult>> Handle(GetTasksByProjectIdQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _taskItemService.GetTasksByProjectIdAsync(request.ProjectId);

            return tasks.Select(task => new UserTaskResult
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Status = task.Status,
                Priority = task.Priority,
                Deadline = task.Deadline,
                CreatedDate = task.CreatedDate,
                ProjectId = task.ProjectId,
                ProjectTitle = task.Project?.Title,
                AssignedToUser = task.AssignedToUser?.FullName
            }).ToList();
        }
    }
    }
