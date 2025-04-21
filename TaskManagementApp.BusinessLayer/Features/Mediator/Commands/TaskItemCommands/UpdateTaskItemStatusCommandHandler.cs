using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands
{
    public class UpdateTaskItemStatusCommand : IRequest
    {
        public int Id { get; set; }
        public string Status { get; set; } // ToDo, InProgress, Done
    }
}
