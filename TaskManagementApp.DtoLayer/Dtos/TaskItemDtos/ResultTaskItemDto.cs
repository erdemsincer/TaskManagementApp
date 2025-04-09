namespace TaskManagementApp.DtoLayer.Dtos.TaskItemDtos
{
    public class ResultTaskItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string AssignedToUser { get; set; }
    }
}
