using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands
{
    public class RemoveTaskItemCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveTaskItemCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
