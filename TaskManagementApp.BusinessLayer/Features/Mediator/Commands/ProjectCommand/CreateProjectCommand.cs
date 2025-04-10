using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand
{
    public class CreateProjectCommand: IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int OwnerUserId { get; set; }
    }
}
