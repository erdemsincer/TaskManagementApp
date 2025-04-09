namespace TaskManagementApp.EntityLayer.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        // Navigation
        public ICollection<User> Users { get; set; }
    }
}
