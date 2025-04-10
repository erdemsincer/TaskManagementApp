using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands
{
    public class UpdateTaskItemCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public int? AssignedToUserId { get; set; }

        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
