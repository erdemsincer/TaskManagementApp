using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class GetProjectWithTasksQueryHandler : IRequestHandler<GetProjectWithTasksQuery, GetProjectWithTasksResult>
    {
        private readonly IProjectService _projectService;

        public GetProjectWithTasksQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<GetProjectWithTasksResult> Handle(GetProjectWithTasksQuery request, CancellationToken cancellationToken)
        {
            var project = await _projectService.GetProjectWithTasksAsync(request.Id);
            if (project == null)
                return null;

            return new GetProjectWithTasksResult
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                CreatedDate = project.CreatedDate,
                Tasks = project.Tasks.Select(t => new UserTaskResult
                {
                    Id = t.Id,
                    Title = t.Title,
                    Status = t.Status,
                    Deadline = t.Deadline
                }).ToList()
            };
        }
    }
}
