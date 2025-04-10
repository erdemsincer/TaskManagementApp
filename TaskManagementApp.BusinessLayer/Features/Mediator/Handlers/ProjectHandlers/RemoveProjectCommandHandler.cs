using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class RemoveProjectCommandHandler : IRequestHandler<RemoveProjectCommand>
    {
        private readonly IProjectService _projectService;

        public RemoveProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task Handle(RemoveProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectService.GetByIdAsync(request.Id);
            if (project != null)
            {
                await _projectService.DeleteAsync(project);
            }
        }
    }
}
