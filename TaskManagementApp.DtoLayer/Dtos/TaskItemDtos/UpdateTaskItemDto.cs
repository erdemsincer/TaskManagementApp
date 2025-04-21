namespace TaskManagementApp.DtoLayer.Dtos.TaskItemDtos
{
    public class UpdateTaskItemDto
    {
        public int Id { get; set; }
        public string Status { get; set; } // ToDo, InProgress, Done
    }
}
