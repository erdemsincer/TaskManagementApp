using MediatR;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Commands.TaskItemCommands
{
    public class CreateTaskItemCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public int? AssignedToUserId { get; set; }

        public string Status { get; set; }  // ToDo, InProgress, Done
        public string Priority { get; set; }  // Low, Medium, High
        public DateTime? Deadline { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
