namespace TaskManagementApp.DtoLayer.Dtos.CommentDtos
{
    public class TaskItemCommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
