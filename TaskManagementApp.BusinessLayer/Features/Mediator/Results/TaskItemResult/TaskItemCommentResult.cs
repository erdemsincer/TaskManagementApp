namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult
{
    public class TaskItemCommentResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
