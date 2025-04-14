using TaskManagementApp.BusinessLayer.Features.Mediator.Results.TaskItemResult;

namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.UserResult
{
    public class GetUserWithTasksResult
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<UserTaskResult> AssignedTasks { get; set; }
    }
}
