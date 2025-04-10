namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult
{
    public class GetTaskItemByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public int? AssignedToUserId { get; set; }

        public string Status { get; set; }  // ToDo, InProgress, Done
        public string Priority { get; set; }  // Low, Medium, High
        public DateTime? Deadline { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<TaskItemCommentResult> Comments { get; set; }
    }
}
