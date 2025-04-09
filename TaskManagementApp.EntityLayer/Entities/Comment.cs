namespace TaskManagementApp.EntityLayer.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int TaskItemId { get; set; }
        public TaskItem TaskItem { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
