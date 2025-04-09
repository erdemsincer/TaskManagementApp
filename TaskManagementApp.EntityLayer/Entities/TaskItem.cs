namespace TaskManagementApp.EntityLayer.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }

        public string Status { get; set; }  // ToDo, InProgress, Done
        public string Priority { get; set; }  // Low, Medium, High
        public DateTime? Deadline { get; set; }
        public DateTime CreatedDate { get; set; }

        // Navigation
        public ICollection<Comment> Comments { get; set; }
    }
}
