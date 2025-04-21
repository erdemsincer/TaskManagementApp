namespace TaskManagementApp.DtoLayer.Dtos.ProjectDtos
{
    public class ResultProjectWithTasksDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<ProjectTaskDto> Tasks { get; set; } // ⬅ başka dosyada tanımlanacak
    }
}
