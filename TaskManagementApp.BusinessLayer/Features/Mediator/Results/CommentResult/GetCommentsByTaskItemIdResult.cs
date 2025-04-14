namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult
{
    public class GetCommentsByTaskItemIdResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public string UserFullName { get; set; } // Yorum yapanın adı
    }
}
