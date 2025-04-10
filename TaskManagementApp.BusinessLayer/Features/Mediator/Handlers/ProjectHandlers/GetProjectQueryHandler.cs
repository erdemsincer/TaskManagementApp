using AutoMapper;
using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class GetProjectQueryHandler :IRequestHandler<GetProjectQuery, List<GetProjectQueryResult>>
    {

        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public GetProjectQueryHandler(IProjectService projectService, IMapper mapper)
        {
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<List<GetProjectQueryResult>> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var projects = await _projectService.GetAllAsync();
            var projectResults = projects.Select(p => new GetProjectQueryResult
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                CreatedDate = p.CreatedDate,
                OwnerUserId = p.OwnerUserId
            }).ToList();

            return projectResults;
        }
    }
}
