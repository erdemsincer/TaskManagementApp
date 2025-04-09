namespace TaskManagementApp.DtoLayer.Dtos.CommentDtos
{
    public class CreateCommentDto
    {
        public int TaskItemId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}
