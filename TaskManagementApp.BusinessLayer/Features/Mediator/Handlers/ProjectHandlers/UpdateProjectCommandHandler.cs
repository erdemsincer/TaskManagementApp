using MediatR;
using TaskManagementApp.BusinessLayer.Abstract;
using TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Handlers.ProjectHandlers
{
    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand>
    {
        private readonly IProjectService _projectService;

        public UpdateProjectCommandHandler(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public async Task Handle(UpdateProjectCommand request,CancellationToken cancellationToken)
        {
            var values = await _projectService.GetByIdAsync(request.Id);
            values.Description = request.Description;
            values.Title = request.Title;
            values.CreatedDate = request.CreatedDate;
            await _projectService.UpdateAsync(values);
        }
    }
}
