using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand>
    {
        private readonly IProjectService _projectService;

        public CreateProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            await _projectService.AddAsync(new EntityLayer.Entities.Project
            {
                Title = request.Title,
                Description = request.Description,
                OwnerUserId = request.OwnerUserId
            });
        }
    }
}
