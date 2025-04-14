using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Queries.ProjectQueries;
using TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class GetAllProjectsWithOwnerQueryHandler : IRequestHandler<GetAllProjectsWithOwnerQuery, List<GetAllProjectsWithOwnerResult>>
    {
        private readonly IProjectService _projectService;

        public GetAllProjectsWithOwnerQueryHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task<List<GetAllProjectsWithOwnerResult>> Handle(GetAllProjectsWithOwnerQuery request, CancellationToken cancellationToken)
        {
            var values = await _projectService.GetAllWithOwnerAsync();

            return values.Select(x => new GetAllProjectsWithOwnerResult
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                CreatedDate = x.CreatedDate,
                OwnerUserId = x.OwnerUserId,
                OwnerFullName = x.OwnerUser?.FullName
            }).ToList();
        }
    }
}
