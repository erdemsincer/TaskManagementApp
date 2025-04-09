namespace TaskManagementApp.EntityLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public DateTime CreatedDate { get; set; }

        // Navigation
        public ICollection<Project> OwnedProjects { get; set; }
        public ICollection<TaskItem> AssignedTasks { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
