using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.ProjectResult
{
    public class GetProjectWithTasksResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<UserTaskResult> Tasks { get; set; } // 🔥 Tek tip
    }
}
