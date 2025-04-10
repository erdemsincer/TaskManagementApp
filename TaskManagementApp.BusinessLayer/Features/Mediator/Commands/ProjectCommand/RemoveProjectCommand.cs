using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.ProjectCommand
{
    public class RemoveProjectCommand:IRequest 
    {
        public int Id { get; set; }

        public RemoveProjectCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
