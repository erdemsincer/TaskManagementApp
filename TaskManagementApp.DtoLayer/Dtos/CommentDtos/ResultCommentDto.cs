namespace TaskManagementApp.DtoLayer.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserFullName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
