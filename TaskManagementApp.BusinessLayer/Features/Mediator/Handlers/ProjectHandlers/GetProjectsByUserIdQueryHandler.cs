using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class GetProjectsByUserIdQueryHandler : IRequestHandler<GetProjectsByUserIdQuery, List<GetProjectsByUserIdResult>>
    {
        private readonly IProjectService _projectService;

        public GetProjectsByUserIdQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<List<GetProjectsByUserIdResult>> Handle(GetProjectsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectService.GetProjectsByUserIdAsync(request.UserId);

            return projects.Select(p => new GetProjectsByUserIdResult
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                CreatedDate = p.CreatedDate
            }).ToList();
        }
    }
}
