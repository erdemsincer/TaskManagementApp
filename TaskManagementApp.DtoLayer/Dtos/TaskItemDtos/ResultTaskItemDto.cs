using TaskManagementApp.DtoLayer.Dtos.CommentDtos;

namespace TaskManagementApp.DtoLayer.Dtos.TaskItemDtos
{
    public class ResultTaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string Status { get; set; }         // ToDo, InProgress, Done
        public string Priority { get; set; }       // Low, Medium, High

        public int ProjectId { get; set; }
        public string? ProjectTitle { get; set; }  // Opsiyonel ama detayda gösterilebilir

        public string? AssignedToUser { get; set; } // Full name (null olabilir)
        public DateTime? Deadline { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<TaskItemCommentDto>? Comments { get; set; } = new(); // null olursa boş gelsin
    }
}
