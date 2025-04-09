namespace TaskManagementApp.DtoLayer.Dtos.TaskItemDtos
{
    public class CreateTaskItemDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int? AssignedToUserId { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
