using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class GetProjectByIdQueryHandler : IRequestHandler<GetProjctByIdQuery,GetProjectByIdQueryResult>
    {
        private readonly IProjectService _projectService;

        public GetProjectByIdQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<GetProjectByIdQueryResult> Handle(GetProjctByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _projectService.GetByIdAsync(request.Id);
            return new GetProjectByIdQueryResult
            {
                Id = values.Id,
                Title = values.Title,
                Description = values.Description,
                CreatedDate = values.CreatedDate,
                OwnerUserId = values.OwnerUserId
            };
        }
}
}
