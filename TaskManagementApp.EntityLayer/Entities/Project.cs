namespace TaskManagementApp.EntityLayer.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public int OwnerUserId { get; set; }
        public User OwnerUser { get; set; }

        // Navigation
        public ICollection<TaskItem> Tasks { get; set; }
    }
}
