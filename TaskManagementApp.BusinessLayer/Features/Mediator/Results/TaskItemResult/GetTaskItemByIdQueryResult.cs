namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult
{
    public class GetTaskItemByIdQueryResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string AssignedToUser { get; set; }

        public string Status { get; set; }  // ToDo, InProgress, Done
        public string Priority { get; set; }  // Low, Medium, High
        public DateTime? Deadline { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<TaskItemCommentResult> Comments { get; set; }
    }
}
