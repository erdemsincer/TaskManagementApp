namespace TaskManagementApp.BusinessLayer.Features.Mediator.Results.CommentResult
{
    public class GetCommentByIdQueryResult
    {
        public int Id { get; set; }
        public int TaskItemId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
