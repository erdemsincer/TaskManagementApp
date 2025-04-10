using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand
{
    public class UpdateProjectCommand:IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
