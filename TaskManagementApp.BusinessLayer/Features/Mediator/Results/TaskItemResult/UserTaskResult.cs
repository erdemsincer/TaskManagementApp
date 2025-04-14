namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult
{
    public class UserTaskResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
